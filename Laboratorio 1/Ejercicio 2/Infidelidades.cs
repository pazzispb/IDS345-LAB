using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    internal class Infidelidades
    {
        public int Id { get; set; }
        public string NombreAfectado { get; set; }
        public string ApellidosAfectado { get; set; }
        public string NombreInfiel { get; set; }
        public string ApellidosInfiel { get; set; }
        public string SexoInfiel { get; set; }
        public string SexoAfectado { get; set; }
        public DateTime FechaEvento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string EstadoPareja { get; set; }
        public bool EsLaPrimeraVez { get; set; }

        public string RetornarDatos()
        {
            //Retornar cada atributo de esta clase
            return "Id de la infidelidad: " + this.Id + "\n" +
                "--------------------------------------" + "\n" +
                "Nombre del Afectado: " + this.NombreAfectado + "\n" +
                "Apellidos del Afectado: " + this.ApellidosAfectado + "\n" +
                "Nombre del Infiel: " + this.NombreInfiel + "\n" +
                "Apellidos del Infiel: " + this.ApellidosInfiel + "\n" +
                "Sexo del Infiel: " + this.SexoInfiel + "\n" +
                "Sexo del Afectado: " + this.SexoAfectado + "\n" +
                "Fecha del Evento: " + this.FechaEvento.ToShortDateString() + "\n" +
                "Fecha de Ingreso: " + this.FechaIngreso.ToShortDateString() + "\n" +
                "Estado de la Pareja: " + this.EstadoPareja + "\n" +
                "Es La Primera Vez?: " + (this.EsLaPrimeraVez ? "Si" : "No") + "\n";
        }
        public void Insertar(){
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("InsertarInfidelidad", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreAfectado", this.NombreAfectado);
            cmd.Parameters.AddWithValue("@ApellidosAfectado", this.ApellidosAfectado);
            cmd.Parameters.AddWithValue("@NombreInfiel", this.NombreInfiel);
            cmd.Parameters.AddWithValue("@ApellidosInfiel", this.ApellidosInfiel);
            cmd.Parameters.AddWithValue("@SexoInfiel", this.SexoInfiel);
            cmd.Parameters.AddWithValue("@SexoAfectado", this.SexoAfectado);
            cmd.Parameters.AddWithValue("@FechaEvento", this.FechaEvento);
            cmd.Parameters.AddWithValue("@EstadoPareja", this.EstadoPareja);
            cmd.Parameters.AddWithValue("@EsLaPrimeraVez", this.EsLaPrimeraVez);

            cmd.ExecuteNonQuery();

            conn.Close();

        }

    }
}
