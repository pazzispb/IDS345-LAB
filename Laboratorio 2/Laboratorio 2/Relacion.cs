using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_2
{
    internal class Relacion
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Estado { get; set; }
        public string Nacionalidad { get; set; }
        public string PaisOrigen { get; set; }
        public string TipoDocumentoNovio { get; set; }
        public string DocumentoNovio { get; set; }

        public void AgregarRelacion()
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pazzi\\OneDrive - INTEC\\Escritorio\\DESARROLLO III\\LABORATORIO\\TAREAS LAB-IDS345\\Laboratorio 2\\Laboratorio 2\\Laboratorio2-DB.mdf\";Integrated Security=True");
            conn.Open();

            SqlCommand cmd = new SqlCommand("AgregarRelacion", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TipoDocumento", TipoDocumento);
            cmd.Parameters.AddWithValue("@Documento", Documento);
            cmd.Parameters.AddWithValue("@Nombres", Nombres);
            cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
            cmd.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
            cmd.Parameters.AddWithValue("@Sexo", Sexo);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@Nacionalidad", Nacionalidad);
            cmd.Parameters.AddWithValue("@PaisOrigen", PaisOrigen);
            cmd.Parameters.AddWithValue("@TipoDocumentoNovio", TipoDocumento);
            cmd.Parameters.AddWithValue("@DocumentoNovio", DocumentoNovio);


            cmd.ExecuteNonQuery();
        }

    }
}
