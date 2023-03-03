using Laboratorio_4.MyDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_4
{
    internal class Feligres
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public int Id { get; set; }
        public int TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; } 
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaUltimaConfesion { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public bool Diezmo { get; set; }
        public bool PerteneceComunidad { get; set; }
        public DateTime UltimaVisitaIglesia { get; set; }

        public void InsertarFeligres(int TipoEvento, string Nota)
        {
            int TipEv = TipoEvento;
            tblFeligresesTableAdapter feligres = new tblFeligresesTableAdapter();
            feligres.Connection.Open();
            SqlTransaction transaction = feligres.Connection.BeginTransaction();
            feligres.Transaction = transaction;
            try
            {
                feligres.ppInsertarFeligreses(TipoDocumento, Documento, Nombres, Apellidos, FechaNacimiento, FechaUltimaConfesion, EstadoCivil, Sexo, Diezmo, PerteneceComunidad, UltimaVisitaIglesia, TipoEvento);

                string descripcion = "";
                if (TipoEvento == 1) descripcion = "Mortal";
                else if (TipoEvento == 2) descripcion = "Venial";
                else
                {
                    TipEv = 3;
                    descripcion = "Penitencia";
                }

                feligres.ppInsertEvento(TipoDocumento, Documento, TipoEvento, Nota, descripcion);
                transaction.Commit();
                log.Info("Transaccion confirmada");
            }
            catch(Exception e)
            {
                transaction.Rollback();
                log.Error("Transaccion revertida debido a errores");
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
