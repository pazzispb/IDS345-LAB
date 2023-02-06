/* Autor: Pazzis Paulino
   Laboratorio 1. Ejercicio 2.
   Mandato: Crear una aplicacion para registrar las infidelidades
*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Infidelidades obj = new Infidelidades();

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

                    obj.Insertar();

                    Console.Write("Si desea ingresar otro registro, presione ENTER... ");
                    continuar = Console.ReadKey().KeyChar;

                } while (continuar == (char)13);

                Console.Clear();

                Console.WriteLine("------INFIDELIDADES REGISTRADAS EN LA BASE DE DATOS----------");
                Console.WriteLine("-------------------------------------------------------------");

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                conn.Open();

                SqlDataReader dr = new SqlCommand("SELECT * FROM Infidelidades", conn).ExecuteReader();
                while (dr.Read())
                {
                    obj = new Infidelidades();
                    obj.Id = (int)dr["Id"];
                    obj.NombreAfectado = dr["NombreAfectado"].ToString();
                    obj.ApellidosAfectado = dr["ApellidosAfectado"].ToString();
                    obj.NombreInfiel = dr["NombreInfiel"].ToString();
                    obj.ApellidosInfiel = dr["ApellidosInfiel"].ToString();
                    obj.SexoInfiel = dr["SexoInfiel"].ToString();
                    obj.SexoAfectado = dr["SexoAfectado"].ToString();
                    obj.FechaEvento = (DateTime)dr["FechaEvento"];
                    obj.FechaIngreso = (DateTime)dr["FechaIngreso"];
                    obj.EstadoPareja = dr["EstadoPareja"].ToString();
                    obj.EsLaPrimeraVez = (bool)dr["EsLaPrimeraVez"];

                    Console.WriteLine(obj.RetornarDatos());
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
