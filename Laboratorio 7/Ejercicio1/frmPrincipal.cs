using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Ejercicio1.dsEstudiantesTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class frmPrincipal : Form
    {
        bool celebridad = false;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ofdImagen.ShowDialog();
            if(string.IsNullOrWhiteSpace(ofdImagen.FileName) == false)
            {
                String foto = ofdImagen.FileName;
                Amazon.Rekognition.Model.Image imagen = new Amazon.Rekognition.Model.Image();
                try
                {
                    using (FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read))
                    {
                        byte[] data = null;
                        data = new byte[fs.Length];
                        fs.Read(data, 0, (int)fs.Length);
                        imagen.Bytes = new MemoryStream(data);
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient("AKIAIE5LZMZN4CR6IO5Q", "xUtzMH5IxZmuZYrc9KSN83JE+pgf5J60+FajM65J", RegionEndpoint.USEast1);

                    DetectTextRequest detectTextRequest = new DetectTextRequest()
                    {
                        Image = imagen
                    };

                    DetectTextResponse detectTextResponse = rekognitionClient.DetectText(detectTextRequest);

                    bool textoDetectado = (detectTextResponse.TextDetections.Count() > 0);

                    DetectFacesRequest detectFacesRequest = new DetectFacesRequest()
                    {
                        Image = imagen
                    };

                    DetectFacesResponse detectFacesResponse = rekognitionClient.DetectFaces(detectFacesRequest);

                    bool unaSolaCara = (detectFacesResponse.FaceDetails.Count() == 1);

                    DetectModerationLabelsRequest detectLabelsRequest = new DetectModerationLabelsRequest()
                    {
                        Image = imagen
                    };

                    DetectModerationLabelsResponse detectLabelsResponse = rekognitionClient.DetectModerationLabels(detectLabelsRequest);

                    bool imagenApta = true;
                    foreach (var item in detectLabelsResponse.ModerationLabels)
                    {
                        if (item.Confidence < 90)
                        {
                            imagenApta = false;
                            break;
                        }
                    }

                    if (imagenApta && textoDetectado == false && unaSolaCara)
                    {
                        RecognizeCelebritiesRequest celebridadesRequest = new RecognizeCelebritiesRequest() { Image = imagen };

                        RecognizeCelebritiesResponse celebridadesResponse = rekognitionClient.RecognizeCelebrities(celebridadesRequest);

                        celebridad = (celebridadesResponse.CelebrityFaces.Count() > 0);

                        pbFoto.ImageLocation = foto;
                    }
                    else
                    {
                        MessageBox.Show("La imagen ingresada no es valida para introducir en el sistema", "Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La API no está disponible");
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string TipoDocumento = txtTipoDocumento.Text;
            string Documento = txtDocumento.Text;
            string Nombres = txtNombres.Text;
            string Apellido = txtApellidos.Text;
            DateTime FechaNacimiento = dtpFechaNacimiento.Value;
            string Estado = txtEstado.Text;
            string Foto = pbFoto.ImageLocation;
            decimal PagoInscripcion = 10000;

            tblEstudiantesTableAdapter adaptador = new tblEstudiantesTableAdapter();
            int afectado = adaptador.ppInsertarEstudiante(TipoDocumento, Documento, Nombres, Apellido, FechaNacimiento, celebridad, Estado, PagoInscripcion, Foto);

            if (afectado > 0)
            {
                MessageBox.Show("Estudiante registrado", "Exito");
                frmReporte frmReporte = new frmReporte(TipoDocumento, Documento);
                frmReporte.Show();
            }
        }
    }
}
