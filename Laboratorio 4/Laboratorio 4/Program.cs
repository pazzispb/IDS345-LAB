using Laboratorio_4.MyDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char continuar = (char)13;
            do
            {
                Console.Clear();
                Feligres obj = new Feligres();

                Console.WriteLine("A continuacion, ingrese el las informaciones del feligres: ");

                Console.Write("Ingrese el tipo de documento: ");
                obj.TipoDocumento = Int32.Parse(Console.ReadLine());

                Console.Write("Ingrese el documento: ");
                obj.Documento = Console.ReadLine();

                tblFeligresesTableAdapter feligres = new tblFeligresesTableAdapter();

                if ((int)feligres.ppGetFeligresCount(obj.TipoDocumento, obj.Documento) == 0)
                {
                    Console.Write("Ingrese el nombre: ");
                    obj.Nombres = Console.ReadLine();

                    Console.Write("Ingrese el apellido: ");
                    obj.Apellidos = Console.ReadLine();

                    Console.Write("Ingrese la fecha de nacimiento (yyyy/mm/dd): ");
                    obj.FechaNacimiento = DateTime.Parse(Console.ReadLine());

                    Console.Write("Ingrese la fecha de ultima confesion (yyyy/mm/dd): ");
                    obj.FechaUltimaConfesion = DateTime.Parse(Console.ReadLine());

                    Console.Write("Ingrese el estado civil: ");
                    obj.EstadoCivil = Console.ReadLine();

                    Console.Write("Ingrese el sexo: ");
                    obj.Sexo = Console.ReadLine();

                    Console.Write("Ingrese si diezma (S/N): ");
                    obj.Diezmo = Console.ReadLine().ToLower()[0] == 's' ? true : false;

                    Console.Write("Ingrese si pertenece a una comunidad (S/N): ");
                    obj.PerteneceComunidad = Console.ReadLine().ToLower()[0] == 's' ? true : false;

                    Console.Write("Ingrese la fecha de ultima visita a la iglesia (yyyy/mm/dd):: ");
                    obj.UltimaVisitaIglesia = DateTime.Parse(Console.ReadLine());
                }
                else
                {
                    obj.FechaNacimiento = DateTime.Now;

                    obj.FechaUltimaConfesion = DateTime.Now;

                    obj.UltimaVisitaIglesia = DateTime.Now;
                }
                Console.Write("Ingrese el tipo de evento (1 - Pecado Mortal, 2 - Pecado Venial, 3 - Penitencia): ");
                int TipoEvento = Int32.Parse(Console.ReadLine());

                Console.Write("Ingrese una nota sobre el evento: ");
                string Nota = Console.ReadLine();

                obj.InsertarFeligres(TipoEvento, Nota);
                
                Console.Write("Si desea ingresar otro registro, presione ENTER... ");
                continuar = Console.ReadKey().KeyChar;
            
            } while (continuar == (char)13);
        }
    }
}
