//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ejercicio1
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblGuerra
    {
        public int Id { get; set; }
        public int CodigoGuerra { get; set; }
        public string Pais1 { get; set; }
        public string Pais2 { get; set; }
        public System.DateTime FechaIngreso { get; set; } = DateTime.Now;
        public System.DateTime FechaInicio { get; set; } = DateTime.Now;
        public string PaisGanador { get; set; }
        public int CantidadMuertos { get; set; }
        public int CantidadPresos { get; set; }
        public decimal PerdidaFinanciera { get; set; }
        public string EstadoGuerra { get; set; }
        public int Heridos { get; set; }
        public System.DateTime FechaFin { get; set; } = DateTime.Now;
    }
}
