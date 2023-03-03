using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public partial class Service1 : ServiceBase
    {
        SqlConnection conn;
        SqlCommand cmd;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {

        }

        private void fwsMonitor_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pazzi\\OneDrive - INTEC\\Escritorio\\DESARROLLO III\\LABORATORIO\\TAREAS LAB-IDS345\\Laboratorio 5\\Ejercicio2A\\Ejercicio2.mdf\";Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("ppInsertarEvento", conn);
            var transaccion = conn.BeginTransaction();
            try
            {
                cmd.Transaction = transaccion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreArchivo", e.Name);
                cmd.Parameters.AddWithValue("@Operacion", "Cambio");
                cmd.ExecuteNonQuery();
                transaccion.Commit();
                log.Info("Archivo modificado > " + e.Name + " > " + DateTime.Now);
                conn.Close();
            }
            catch (Exception a)
            {
                transaccion.Rollback();
                log.Error(a.Message);
                conn.Close();
            }
        }

        private void fwsMonitor_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pazzi\\OneDrive - INTEC\\Escritorio\\DESARROLLO III\\LABORATORIO\\TAREAS LAB-IDS345\\Laboratorio 5\\Ejercicio2\\Ejercicio2.mdf\";Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("ppInsertarEvento", conn);
            var transaccion = conn.BeginTransaction();
            try
            {
                cmd.Transaction = transaccion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreArchivo", e.Name);
                cmd.Parameters.AddWithValue("@Operacion", "Creado");
                cmd.ExecuteNonQuery();
                transaccion.Commit();
                log.Info("Archivo creado > " + e.Name + " > " + DateTime.Now);
                conn.Close();

            }
            catch (Exception a)
            {
                transaccion.Rollback();
                log.Error(a.Message);
                conn.Close();
            }
        }

        private void fwsMonitor_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pazzi\\OneDrive - INTEC\\Escritorio\\DESARROLLO III\\LABORATORIO\\TAREAS LAB-IDS345\\Laboratorio 5\\Ejercicio2\\Ejercicio2.mdf\";Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("ppInsertarEvento", conn);
            var transaccion = conn.BeginTransaction();
            try
            {
                cmd.Transaction = transaccion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreArchivo", e.Name);
                cmd.Parameters.AddWithValue("@Operacion", "Borrado");
                cmd.ExecuteNonQuery();
                transaccion.Commit();
                log.Info("Archivo borrado > " + e.Name + " > " + DateTime.Now);
                conn.Close();

            }
            catch (Exception a)
            {
                transaccion.Rollback();
                log.Error(a.Message);
                conn.Close();
            }
        }

        private void fwsMonitor_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\pazzi\\OneDrive - INTEC\\Escritorio\\DESARROLLO III\\LABORATORIO\\TAREAS LAB-IDS345\\Laboratorio 5\\Ejercicio2\\Ejercicio2.mdf\";Integrated Security=True");
            conn.Open();
            cmd = new SqlCommand("ppInsertarEvento", conn);
            var transaccion = conn.BeginTransaction();
            try
            {
                cmd.Transaction = transaccion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NombreArchivo", e.Name);
                cmd.Parameters.AddWithValue("@Operacion", "Renombrado");
                cmd.ExecuteNonQuery();
                transaccion.Commit();
                log.Info("Archivo renombrado > " + e.Name + " > " + DateTime.Now);
                conn.Close();

            }
            catch (Exception a)
            {
                transaccion.Rollback();
                log.Error(a.Message);
                conn.Close();
            }
        }
    }
}
