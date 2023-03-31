using NServiceBus.Logging;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Mensajes;
using Facturacion.Mensaje;
using Ventas.DSOrdenTableAdapters;

namespace Ventas
{
    public class ColocarOrdenHandler :
    IHandleMessages<ColocarOrden>
    {
        static ILog log = LogManager.GetLogger<ColocarOrdenHandler>();

        public Task Handle(ColocarOrden message, IMessageHandlerContext context)
        {
            log.Info($"Nueva orden recibida, Numero de orden = {message.NumeroOrden}, se ha mandado a facturar");

            // This is normally where some business logic would occur
            
            var ordenFacturada = new OrdenFacturada
            {
                NumeroOrden = message.NumeroOrden,
                Descripcion = message.Descripcion,
                Precio = message.Precio,
                Cantidad = message.Cantidad,
                ITBIS = message.ITBIS
            };
            tblOrdenTableAdapter adapter = new tblOrdenTableAdapter();
            adapter.ppInsertarOrden(message.NumeroOrden, message.Descripcion, message.Precio, message.Cantidad, message.ITBIS, "Colocado");

            return context.Publish(ordenFacturada);
        }
    }
}
