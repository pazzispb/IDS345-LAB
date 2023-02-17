using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_3
{
    internal class clsFallecidos
    {
        public int Id { get; set; }
        public int TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Sexo { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public int Estado { get; set; }

        public void InsertarFallecido()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pazzi\\OneDrive - INTEC\\Escritorio\\DESARROLLO III\\LABORATORIO\\TAREAS LAB-IDS345\\Laboratorio 3\\Laboratorio 3\\Laboratorio3-DB.mdf\";Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("ppInsertarFallecidos", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TipoDocumento", TipoDocumento);
            cmd.Parameters.AddWithValue("@Documento", Documento);
            cmd.Parameters.AddWithValue("@Nombres", Nombres);
            cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
            cmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            cmd.Parameters.AddWithValue("@Sexo", Sexo[0]);
            cmd.Parameters.AddWithValue("@Pais", Pais);
            cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
            cmd.Parameters.AddWithValue("@Estado", Estado);

            SqlTransaction tran = con.BeginTransaction();
            cmd.Transaction = tran;
            try
            {
                cmd.ExecuteNonQuery();
                
                cmd.Parameters.Clear();
                cmd.CommandText = "ppUpsertResumen";
                cmd.Parameters.AddWithValue("@Pais", Pais);
                cmd.Parameters.AddWithValue("@Ciudad", Ciudad);
                cmd.Parameters.AddWithValue("@Sexo", Sexo[0]);

                cmd.ExecuteNonQuery();

                tran.Commit();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Hubo un error en la operacion, los cambios se revirtieron");
                tran.Rollback();
            }
        }

    }
}
