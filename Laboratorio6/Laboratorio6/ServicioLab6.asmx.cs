using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;

namespace Laboratorio6
{
    /// <summary>
    /// Summary description for ServicioLab6
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioLab6 : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [WebMethod]
        public Respuesta RegistrarVerdugo(string descripcion, tblVerdugo verdugo)
        {
            Respuesta respuesta;
            using (Entities entities = new Entities())
            {
                entities.Database.Connection.Open();
                var transaccion = entities.Database.Connection.BeginTransaction();
                entities.Database.UseTransaction(transaccion);
                try
                {
                    entities.ppInsertVerdugo(verdugo.TipoDocumento, verdugo.Documento, verdugo.Nombres, verdugo.Apellidos, verdugo.FNacimiento, verdugo.FEvento, verdugo.CantidadHijos, verdugo.Vivo, verdugo.Preso);
                    entities.ppInsertarIndicios(verdugo.TipoDocumento, verdugo.Documento, descripcion);
                    transaccion.Commit();
                    log.Info($"Verdugo e incidentes registrados");
                    respuesta = new Respuesta()
                    {
                        Codigo = 0,
                        Mensaje = "Verdugo registrado"
                    };
                }
                catch(Exception e)
                {
                    log.Error($"Hubo un error al guardar al verdugo");
                    transaccion.Rollback();
                    respuesta = new Respuesta()
                    {
                        Codigo = 0,
                        Mensaje = "Hubo un error al guardar al verdugo"
                    };
                }
            }
            return respuesta;
        }
    }
}
