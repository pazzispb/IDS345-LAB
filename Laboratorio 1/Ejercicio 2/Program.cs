using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Indicando al DataDirectory de la cadena de conexión la ubicación archivo mdf de la base de datos 
            var currentDomain = AppDomain.CurrentDomain;
            var basePath = currentDomain.BaseDirectory;

            basePath = basePath.Substring(0, basePath.LastIndexOf('\\'));
            basePath = basePath.Substring(0, basePath.LastIndexOf('\\'));
            basePath = basePath.Substring(0, basePath.LastIndexOf('\\'));

            currentDomain.SetData("DataDirectory", basePath + "\\");

            //--------------------------------------------------------------------

            using (Entities db = new Entities())
            {
                Infidelidade obj = new Infidelidade();

                try
                {
                    char continuar = (char)13;
                    do
                    {
                        Console.Clear();

                        Console.WriteLine("A continuacion, ingrese los datos de la infidelidad: ");

                        Console.Write("Nombre del afectado: ");
                        obj.NombreAfectado = Console.ReadLine();

                        Console.Write("Apellido del afectado: ");
                        obj.ApellidosAfectado = Console.ReadLine();

                        Console.Write("Sexo del afectado: ");
                        obj.SexoAfectado = Console.ReadLine();

                        Console.Write("Nombre del infiel: ");
                        obj.NombreInfiel = Console.ReadLine();

                        Console.Write("Apellido del infiel: ");
                        obj.ApellidosInfiel = Console.ReadLine();

                        Console.Write("Sexo del infiel: ");
                        obj.SexoInfiel = Console.ReadLine();

                        Console.Write("Fecha de la infidelidad (mm/dd/aaaa): ");
                        obj.FechaEvento = DateTime.Parse(Console.ReadLine());

                        Console.Write("Estado de la pareja: ");
                        obj.EstadoPareja = Console.ReadLine();

                        Console.Write("Es la primera vez? (S/N): ");
                        char PrimeraVez = Console.ReadLine().ToUpper()[0];
                        obj.EsLaPrimeraVez = (PrimeraVez == 'S') ? true : false;

                        obj.FechaIngreso = DateTime.Now;

                        db.Infidelidades.Add(obj);

                        db.SaveChanges();

                        Console.Write("Si desea ingresar otro registro, presione ENTER... ");
                        continuar = Console.ReadKey().KeyChar;

                    } while (continuar == (char)13);

                    Console.Clear();

                    Console.WriteLine("------INFIDELIDADES REGISTRADAS EN LA BASE DE DATOS----------");
                    Console.WriteLine("-------------------------------------------------------------");

                    var tabla = db.Infidelidades;

                    foreach (var item in tabla)
                    {
                        Console.Write(item.RetornarDatos());
                        Console.WriteLine("..............................................\n");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}