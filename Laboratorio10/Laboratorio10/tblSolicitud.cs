//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laboratorio10
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSolicitud
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public Nullable<System.DateTime> FechaSolicitud { get; set; }
        public string Estado { get; set; }
        public string NivelAcademicoDonante { get; set; }
        public Nullable<decimal> EstaturaDonante { get; set; }
        public Nullable<decimal> TamanoPiesDonante { get; set; }
        public string ColorOjosDonante { get; set; }
        public string NacionalidadDonante { get; set; }
        public string Descripcion { get; set; }
        public string EdadPromedioDonante { get; set; }
    }
}