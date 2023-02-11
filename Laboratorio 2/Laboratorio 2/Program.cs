using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char continuar = (char)13;
            Persona obj;
            do
            {
                obj = new Persona();
                Console.Clear();

                Console.WriteLine("A continuacion, ingrese sus datos: ");

                Console.Write("Tipo Documento: ");
                obj.TipoDocumento = Console.ReadLine();
                
                Console.Write("Documento: ");
                obj.Documento = Console.ReadLine();

                Console.Write("Nombres: ");
                obj.Nombres = Console.ReadLine();

                Console.Write("Apellidos: ");
                obj.Apellidos = Console.ReadLine();

                Console.Write("Fecha de Nacimiento (yyyy-mm-dd): ");
                obj.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Sexo: ");
                obj.Sexo = Console.ReadLine();
                

                Console.Write("Estado: ");
                obj.Estado = Console.ReadLine();

                Console.Write("Nacionalidad: ");
                obj.Nacionalidad = Console.ReadLine();

                Console.Write("Pais de Origen: ");
                obj.PaisOrigen = Console.ReadLine();


                Console.Write("Cantidad: ");
                obj.Cantidad = Int32.Parse(Console.ReadLine());

                obj.InsertarPersona();

                Relacion rel;
                
                for(int i = 0; i < obj.Cantidad; i++)
                {
                    rel = new Relacion();
                        
                    Console.WriteLine($"A continuacion, los datos de la pareja No. {i+1}: ");

                    Console.Write("Tipo Documento: ");
                    rel.TipoDocumento = Console.ReadLine();

                    Console.Write("Documento: ");
                    rel.Documento = Console.ReadLine();

                    Console.Write("Nombres: ");
                    rel.Nombres = Console.ReadLine();

                    Console.Write("Apellidos: ");
                    rel.Apellidos = Console.ReadLine();

                    Console.Write("Fecha de Nacimiento (yyyy-mm-dd): ");
                    rel.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("Sexo: ");
                    rel.Sexo = Console.ReadLine();

                    Console.Write("Estado: ");
                    rel.Estado = Console.ReadLine();

                    Console.Write("Nacionalidad: ");
                    rel.Nacionalidad = Console.ReadLine();

                    Console.Write("Pais de Origen: ");
                    rel.PaisOrigen = Console.ReadLine();

                    rel.TipoDocumentoNovio = obj.TipoDocumento;
                    rel.DocumentoNovio = obj.Documento;

                    rel.AgregarRelacion();
                }

                Console.Write("Si desea ingresar otro registro, presione ENTER... ");
                continuar = Console.ReadKey().KeyChar;

            } while (continuar == (char)13);

            Console.Clear();
            
        }
    }
}
