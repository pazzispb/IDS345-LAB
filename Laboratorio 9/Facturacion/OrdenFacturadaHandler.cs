using NServiceBus.Logging;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facturacion.Mensaje;
using Facturacion.DSOrdenTableAdapters;

namespace Facturacion
{
    public class OrdenFacturadaHandler :
        IHandleMessages<OrdenFacturada>
    {
        static ILog log = LogManager.GetLogger<OrdenFacturadaHandler>();

        public Task Handle(OrdenFacturada message, IMessageHandlerContext context)
        {
            log.Info($"Nueva orden recibida, OrderId = {message.NumeroOrden} - Facturando...");
            tblOrdenTableAdapter adapter = new tblOrdenTableAdapter();
            adapter.ppInsertarOrden(message.NumeroOrden, message.Descripcion, message.Precio, message.Cantidad, message.ITBIS, "Facturado");

            return Task.CompletedTask;
        }
    }
}
