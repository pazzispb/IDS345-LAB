using Ejercicio1.dsActividadesTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicio1
{
    public partial class frmActividades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            tblActividadTableAdapter adaptador = new tblActividadTableAdapter();
            adaptador.InsertarActividad(txtDescripcion.Text, dtpFechaActividad.SelectedDate, txtEstado.Text, txtCodigoActividad.Text);
            txtDescripcion.Text = "";
            txtEstado.Text = "";
            txtCodigoActividad.Text = "";
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            if (chbFiltrar.Checked)
            {
                tblInscritosTableAdapter adaptador = new tblInscritosTableAdapter();
                var registro = adaptador.GetDataByCodigoActividad(txtCodigoActividadR.Text);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
                {
                    Name = "dsActividades",
                    Value = registro
                });
            }
            else
            {
                tblInscritosTableAdapter adaptador = new tblInscritosTableAdapter();
                var registro = adaptador.GetData();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource()
                {
                    Name = "dsActividades",
                    Value = registro
                });
            }
        }
    }
}