using Ejercicio1.dsActividadesTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicio1
{
    public partial class frmIncristos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            tblInscritosTableAdapter adaptador = new tblInscritosTableAdapter();
            adaptador.InsertarInscrito(txtTipoDocumento.Text, txtDocumento.Text, txtNombres.Text,
                txtApellidos.Text, dtpFechaNacimiento.SelectedDate, txtSexo.Text, txtEstado.Text, txtTipo.Text, txtCodigoActividad.Text);

            var registro = adaptador.GetDataByMostrarInscrito(txtTipoDocumento.Text, txtDocumento.Text, txtCodigoActividad.Text);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
            {
                Name = "dsActividades",
                Value = registro
            });
            
            txtApellidos.Text = "";
            txtCodigoActividad.Text = "";
            txtDocumento.Text = "";
            txtEstado.Text = "";
            txtNombres.Text = "";
            txtSexo.Text = "";
            txtTipo.Text = "";
            txtTipoDocumento.Text = "";
            
        }
    }
}