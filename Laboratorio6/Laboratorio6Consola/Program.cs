using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorio6Consola.WS;

namespace Laboratorio6Consola
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            char continuar = (char)13;
            do
            {
                Console.Clear();
                tblVerdugo obj = new tblVerdugo();

                Console.WriteLine("A continuacion, ingrese el las informaciones del verdugo: ");

                Console.Write("Ingrese el tipo de documento: ");
                obj.TipoDocumento = Int32.Parse(Console.ReadLine());

                Console.Write("Ingrese el documento: ");
                obj.Documento = Console.ReadLine();

                Console.Write("Ingrese el nombre: ");
                obj.Nombres = Console.ReadLine();

                Console.Write("Ingrese el apellido: ");
                obj.Apellidos = Console.ReadLine();

                Console.Write("Ingrese la fecha de nacimiento (yyyy/mm/dd): ");
                obj.FNacimiento = DateTime.Parse(Console.ReadLine());

                Console.Write("Ingrese la fecha del evento (yyyy/mm/dd): ");
                obj.FEvento = DateTime.Parse(Console.ReadLine());

                Console.Write("Cantidad de hijos: ");
                obj.CantidadHijos = int.Parse(Console.ReadLine());

                Console.Write("Esta preso? (S/N): ");
                obj.Preso = Console.ReadLine().ToLower()[0] == 's' ? true : false;

                Console.Write("Esta vivo? (S/N): ");
                obj.Vivo = Console.ReadLine().ToLower()[0] == 's' ? true : false;

                Console.Write("Ingrese una descripcion del indicio: ");
                string descripcion = Console.ReadLine();

                ServicioLab6SoapClient servicio = new ServicioLab6SoapClient();
                
                Respuesta respuesta = servicio.RegistrarVerdugo(descripcion, obj);

                Console.WriteLine(respuesta.Mensaje);
                log.Info(respuesta.Mensaje);
                
                Console.Write("Si desea ingresar otro registro, presione ENTER... ");
                continuar = Console.ReadKey().KeyChar;

            } while (continuar == (char)13);
            
        }
    }
}
