using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laboratorio_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char continuar = (char)13;
            clsFallecidos obj;
            do
            {
                obj = new clsFallecidos();
                Console.Clear();

                
                Console.WriteLine("A continuacion, ingrese los datos del muerto: ");

                Console.Write("Pais: ");
                obj.Pais = Console.ReadLine();

                Console.Write("Ciudad: ");
                obj.Ciudad = Console.ReadLine();

                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pazzi\\OneDrive - INTEC\\Escritorio\\DESARROLLO III\\LABORATORIO\\TAREAS LAB-IDS345\\Laboratorio 3\\Laboratorio 3\\Laboratorio3-DB.mdf\";Integrated Security=True");
                con.Open();

                SqlCommand cmd = new SqlCommand("ppGetCiudad", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Pais", obj.Pais);
                cmd.Parameters.AddWithValue("@Ciudad", obj.Ciudad);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("Cantidad de hombres en la ciudad: " + reader["CantidadHombres"].ToString());
                    Console.WriteLine("Cantidad de mujeres en la ciudad: " + reader["CantidadMujeres"].ToString());
                }

                reader.Close();

                con.Close();

                Console.Write("Tipo Documento: ");
                obj.TipoDocumento = Int32.Parse(Console.ReadLine());

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
                
               

                obj.InsertarFallecido();

                Console.Write("Si desea ingresar otro registro, presione ENTER... ");
                continuar = Console.ReadKey().KeyChar;

            } while (continuar == (char)13);

            Console.Clear();
        }
    }
}
