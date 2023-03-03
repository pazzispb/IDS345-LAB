using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            char continuar = (char)13;
            Entities entities = new Entities();
            do
            {
                Console.Clear();

                Console.WriteLine("A continuacion, ingrese los datos de la guerra: ");
                tblGuerra guerra = new tblGuerra();

                Console.Write("Codigo: ");
                guerra.CodigoGuerra = int.Parse(Console.ReadLine());

                if (!entities.tblGuerras.Any(x => x.CodigoGuerra == guerra.CodigoGuerra))
                {
                    Console.Write("Pais 1: ");
                    guerra.Pais1 = Console.ReadLine();

                    Console.Write("Pais 2: ");
                    guerra.Pais2 = Console.ReadLine();

                    Console.Write("Fecha Inicio: ");
                    guerra.FechaInicio = DateTime.Parse(Console.ReadLine());

                    Console.Write("FechaFin: ");
                    guerra.FechaFin = DateTime.Parse(Console.ReadLine());

                    Console.Write("Pais ganador: ");
                    guerra.PaisGanador = Console.ReadLine();

                    Console.Write("Cantidad de presos: ");
                    guerra.CantidadPresos = int.Parse(Console.ReadLine());

                    Console.Write("Perdida financiera: ");
                    guerra.PerdidaFinanciera = decimal.Parse(Console.ReadLine());

                    Console.Write("Estado: ");
                    guerra.EstadoGuerra = Console.ReadLine();
                }

                Console.WriteLine("A continuacion, ingrese los datos del evento: ");
                tblEvento evento = new tblEvento();

                Console.Write("Tipo: ");
                evento.TipoEvento = int.Parse(Console.ReadLine());

                Console.Write("Descripcion: ");
                evento.Descripcion = Console.ReadLine();

                Console.Write("Fecha del evento: ");
                evento.FechaEvento = DateTime.Parse(Console.ReadLine());

                Console.Write("Cantidad de presos: ");
                evento.CantidadHeridos = int.Parse(Console.ReadLine());

                Console.Write("Cantidad de muertos: ");
                evento.CantidadMuertos = int.Parse(Console.ReadLine());

                entities.Database.Connection.Open();
                var transaccion = entities.Database.Connection.BeginTransaction();
                entities.Database.UseTransaction(transaccion);
                try
                {
                    entities.ppInsertEvento(guerra.CodigoGuerra, evento.TipoEvento, evento.Descripcion, evento.FechaEvento, evento.CantidadMuertos, evento.CantidadHeridos);

                    entities.ppUpsertGuerra(guerra.CodigoGuerra, guerra.Pais1, guerra.Pais2, guerra.FechaInicio, guerra.FechaFin, guerra.PaisGanador, evento.CantidadMuertos, guerra.CantidadPresos, guerra.PerdidaFinanciera, guerra.EstadoGuerra, evento.CantidadHeridos);

                    entities.SaveChanges();

                    transaccion.Commit();
                    log.Info("Evento agregado a Guerra de codigo " + guerra.CodigoGuerra);
                }
                catch (Exception e)
                {
                    log.Error(e.Message);
                    transaccion.Rollback();
                }

                Console.Write("Si desea ingresar otro registro, presione ENTER... ");
                continuar = Console.ReadKey().KeyChar;

            } while (continuar == (char)13);
        }
    }
}
