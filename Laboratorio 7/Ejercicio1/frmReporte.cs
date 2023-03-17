using Ejercicio1.dsEstudiantesTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class frmReporte : Form
    {
        string tipo, documento;
        public frmReporte(string tipo, string documento)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.documento = documento;
        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            tblEstudiantesTableAdapter adaptador = new tblEstudiantesTableAdapter();
            var registros = adaptador.GetEstudiante(tipo, documento);
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource()
            {
                Value = registros,
                Name = "dsEstudiantes"
            });

            this.reportViewer1.RefreshReport();
        }
    }
}
