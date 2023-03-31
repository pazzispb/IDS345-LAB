using NServiceBus.Logging;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Mensajes;
using Facturacion.Mensaje;

namespace Ventas
{
    public class ColocarOrdenHandler :
    IHandleMessages<ColocarOrden>
    {
        static ILog log = LogManager.GetLogger<ColocarOrdenHandler>();

        public Task Handle(ColocarOrden message, IMessageHandlerContext context)
        {
            log.Info($"Received PlaceOrder, OrderId = {message.NumeroOrden}");
            
            // This is normally where some business logic would occur

            var ordenFacturada = new OrdenFacturada
            {
                NumeroOrden = message.NumeroOrden,
                Descripcion = message.Descripcion,
                Precio = message.Precio,
                Cantidad = message.Cantidad,
                ITBIS = message.ITBIS
            };
            return context.Publish(ordenFacturada);
        }
    }
}
