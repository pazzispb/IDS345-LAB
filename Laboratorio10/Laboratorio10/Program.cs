using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static System.Net.Mime.MediaTypeNames;

namespace Laboratorio10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char sel = '1';
            do
            {
                var entitdad = new Entities();
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("1. Ingresar solicitud");
                Console.WriteLine("2. Ver todas las solicitudes");
                Console.WriteLine("3. Salir");
                Console.Write("Opcion elegida: ");
                sel = Console.ReadLine()[0];
                switch (sel)
                {
                    case '1':
                        {
                            Console.Clear();
                            var solicitante = new tblSolicitante();
                            Console.WriteLine("Ingrese los datos del solicitante:");
                            Console.Write("Tipo de documento: ");
                            solicitante.TipoDocumento = Console.ReadLine();
                            Console.Write("Documento: ");
                            solicitante.Documento = Console.ReadLine();
                            Console.Write("Fecha de nacimiento: ");
                            solicitante.FNacimiento = DateTime.Parse(Console.ReadLine());
                            Console.Write("Estado: ");
                            solicitante.Estado = Console.ReadLine();
                            Console.Write("Nombres: ");
                            solicitante.Nombres = Console.ReadLine();
                            Console.Write("Apellidos: ");
                            solicitante.Apellidos = Console.ReadLine();
                            Console.Write("Direccion: ");
                            solicitante.Direccion = Console.ReadLine();
                            Console.Write("Estado Civil: ");
                            solicitante.EstadoCivil = Console.ReadLine();
                            Console.Write("Lo aprobo el esposo?: ");
                            solicitante.AprobadoEsposo = Console.ReadLine();
                            Console.WriteLine("Ingrese los datos de la solicitud:");
                            var solicitud = new tblSolicitud();
                            Console.Write("Estado: ");
                            solicitud.Estado = Console.ReadLine();
                            Console.Write("Nivel academico del donante: ");
                            solicitud.NivelAcademicoDonante = Console.ReadLine();
                            Console.Write("Estatura del donante: ");
                            solicitud.EstaturaDonante = Decimal.Parse(Console.ReadLine());
                            Console.Write("Tamaño de pies del donante: ");
                            solicitud.TamanoPiesDonante = Decimal.Parse(Console.ReadLine());
                            Console.Write("Color de ojos del donante: ");
                            solicitud.ColorOjosDonante = Console.ReadLine();
                            Console.Write("Nacionalidad del donante: ");
                            solicitud.NacionalidadDonante = Console.ReadLine();
                            Console.Write("Descripcion del donante: ");
                            solicitud.Descripcion = Console.ReadLine();
                            Console.Write("Edad promedio del donante: ");
                            solicitud.EdadPromedioDonante = Console.ReadLine();

                            var entites = new Entities();
                            entites.spInsertarSolicitante(solicitante.TipoDocumento, solicitante.Documento, solicitante.FNacimiento, solicitante.Estado, solicitante.Nombres, solicitante.Apellidos, solicitante.Direccion, solicitante.EstadoCivil, solicitante.AprobadoEsposo);
                            entites.spInsertarSolicitud(solicitante.TipoDocumento, solicitante.Documento, solicitud.Estado, solicitud.NivelAcademicoDonante, solicitud.EstaturaDonante, solicitud.TamanoPiesDonante, solicitud.ColorOjosDonante, solicitud.NacionalidadDonante, solicitud.Descripcion, solicitud.EdadPromedioDonante);
                            entites.SaveChanges();
                            Console.Clear();
                            
                            var solicitante_constancia = entites.tblSolicitantes.FirstOrDefault(x=> x.TipoDocumento == solicitante.TipoDocumento && x.Documento == solicitante.Documento);
                            var solicitud_constancia = entites.tblSolicituds.FirstOrDefault(x => x.TipoDocumento == solicitante.TipoDocumento && x.Documento == solicitante.Documento);
                            var texto = "----------------- CONSTANCIA DE SOLICITUD -------------------\n"
                            + "_____________________________________________________________\n"
                            + "                  Datos del solicitante                      \n"
                            + "_____________________________________________________________\n"
                            + $" * ID: {solicitante_constancia.Id}       \n"
                            + $" * Codigo documento: {solicitante_constancia.Documento}       \n"
                            + $" * Tipo documento: {solicitante_constancia.TipoDocumento}     \n"
                            + $" * Fecha de nacimiento: {solicitante_constancia.FNacimiento.ToString()}     \n"
                            + $" * Fecha de ingreso al sistema: {solicitante_constancia.FIngreso.ToString()}     \n"
                            + $" * Estado: {solicitante_constancia.Estado}     \n"
                            + $" * Nombres: {solicitante_constancia.Nombres}     \n"
                            + $" * Apellidos: {solicitante_constancia.Apellidos}     \n"
                            + $" * Direccion: {solicitante_constancia.Direccion}     \n"
                            + $" * Estado Civil: {solicitante_constancia.EstadoCivil}     \n"
                            + $" * Aprobado por el esposo?: {solicitante_constancia.AprobadoEsposo}     \n"
                            + "_____________________________________________________________\n"
                            + "                  Datos de la solicitud                      \n"
                            + "_____________________________________________________________\n"
                            + $" * ID: {solicitud_constancia.Id}     \n"
                            + $" * Fecha de emision de la solicitud: {solicitud_constancia.FechaSolicitud.ToString()}     \n"
                            + $" * Estado: {solicitud_constancia.Estado}     \n"
                            + $" * Nivel academico del donante: {solicitud_constancia.NivelAcademicoDonante}     \n"
                            + $" * Tamaño de pies del donante: {solicitud_constancia.TamanoPiesDonante.ToString()}     \n"
                            + $" * Estatura del donante: {solicitud_constancia.EstaturaDonante.ToString()}     \n"
                            + $" * Color de ojos del donante: {solicitud_constancia.ColorOjosDonante}     \n"
                            + $" * Nacionalidad del donante: {solicitud_constancia.NacionalidadDonante}     \n"
                            + $" * Descripcion del donante: {solicitud_constancia.Descripcion}     \n"
                            + $" * Edad promedio del donante: {solicitud_constancia.EdadPromedioDonante}     \n"
                            + "_____________________________________________________________\n";
                            Document doc = new Document();

                            // Create a new PDF file stream
                            PdfWriter.GetInstance(doc, new FileStream("Constancia.pdf", FileMode.Create));

                            // Open the PDF document
                            doc.Open();

                            // Add some text to the PDF document
                            doc.Add(new Paragraph(texto));

                            // Close the PDF document
                            doc.Close();
                            Console.ReadKey();
                            break;
                        }
                    case '2':
                        {
                            Console.Clear();
                            var reporte = "----------------- REPORTE DE TODAS LAS SOLICITUDES -------------------\n";
                            var entities = new Entities();
                            var solicitantes = entities.tblSolicitantes.ToList();
                            foreach (var item in entities.tblSolicituds)
                            {
                                var solicitante = solicitantes.FirstOrDefault(x => x.TipoDocumento == item.TipoDocumento && x.Documento == item.Documento);
                                var nombre = solicitante.Nombres + " " + solicitante.Apellidos;
                                reporte += "_____________________________________________________________\n"
                                + $"ID de la solicitud: {item.Id}\n"
                                + $" \t* Nombre del solicitante: {nombre}     \n"
                                + $" \t* Fecha de emision de la solicitud: {item.FechaSolicitud.ToString()}     \n"
                                + $" \t* Estado: {item.Estado}     \n"
                                + $" \t* Nivel academico del donante: {item.NivelAcademicoDonante}     \n"
                                + $" \t* Tamaño de pies del donante: {item.TamanoPiesDonante.ToString()}     \n"
                                + $" \t* Estatura del donante: {item.EstaturaDonante.ToString()}     \n"
                                + $" \t* Color de ojos del donante: {item.ColorOjosDonante}     \n"
                                + $" \t* Nacionalidad del donante: {item.NacionalidadDonante}     \n"
                                + $" \t* Descripcion del donante: {item.Descripcion}     \n"
                                + $" \t* Edad promedio del donante: {item.EdadPromedioDonante}     \n";
                            }
                            Document doc = new Document();

                            // Create a new PDF file stream
                            PdfWriter.GetInstance(doc, new FileStream("ReporteGeneral.pdf", FileMode.Create));

                            // Open the PDF document
                            doc.Open();

                            // Add some text to the PDF document
                            doc.Add(new Paragraph(reporte));

                            // Close the PDF document
                            doc.Close();
                            Console.ReadKey();
                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine("Gracias por utilizar la aplicacion");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (sel != '3');            
            
        }
    }
}
