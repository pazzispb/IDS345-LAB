using NServiceBus.Logging;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Mensajes;
using ClienteUI.DSOrdenTableAdapters;

namespace ClienteUI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "ClienteUI";

            var endpointConfiguration = new EndpointConfiguration("ClienteUI");

            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(ColocarOrden), "Ventas");

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            await RunLoop(endpointInstance)
                .ConfigureAwait(false);

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
        static ILog log = LogManager.GetLogger<Program>();

        static async Task RunLoop(IEndpointInstance endpointInstance)
        {
            while (true)
            {
                log.Info("Presiona 'P' para colocar una orden, o 'Q' para salir.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                        // Instantiate the command
                        
                        var command = new ColocarOrden
                        {
                            NumeroOrden = Guid.NewGuid().ToString()
                        };
                        Console.Write("Descripcion: ");
                        command.Descripcion = Console.ReadLine();
                        Console.Write("Precio: ");
                        command.Precio = decimal.Parse(Console.ReadLine());
                        Console.Write("ITBIS: ");
                        command.ITBIS = decimal.Parse(Console.ReadLine());
                        Console.Write("Cantidad: ");
                        command.Cantidad = int.Parse(Console.ReadLine());
                        
                        tblOrdenTableAdapter adapter = new tblOrdenTableAdapter();
                        adapter.ppInsertarOrden(command.NumeroOrden, command.Descripcion, command.Precio, command.Cantidad, command.ITBIS, "Ordenado");
                        // Send the command to the local endpoint
                        
                        log.Info($"Enviando la orden, OrderId = {command.NumeroOrden}");
                        await endpointInstance.Send(command)
                            .ConfigureAwait(false);

                        break;

                    case ConsoleKey.Q:
                        return;

                    default:
                        log.Info("Entrada desconocida. Intente de nuevo.");
                        break;
                }
            }
        }
    }
}
