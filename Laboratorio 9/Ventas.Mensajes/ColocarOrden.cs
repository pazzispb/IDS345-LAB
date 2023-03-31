﻿using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Mensajes
{
    public class ColocarOrden :
        ICommand
    {
        public string NumeroOrden { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal ITBIS { get; set; }

    }
}