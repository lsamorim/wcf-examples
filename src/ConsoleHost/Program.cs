using System;
using System.ServiceModel;
using WcfServiceLibrary1;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(InvoiceService));

            //host.AddServiceEndpoint(
            //    typeof(IInvoiceService),
            //    new BasicHttpBinding(),
            //    "http://localhost:1010/invoice/basic");

            //host.AddServiceEndpoint(
            //    typeof(IInvoiceService),
            //    new WSHttpBinding(),
            //    "http://localhost:1010/invoice/ws");

            //host.AddServiceEndpoint(
            //    typeof(IInvoiceService),
            //    new NetTcpBinding(),
            //    "net.tcp://localhost:1011/invoice");

            try
            {
                host.Open();
                PrintServiceInfo(host);
                Console.ReadKey();
                host.Close();
                Console.WriteLine("Host closed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                host.Abort();

                Console.ReadKey();
            }
        }

        private static void PrintServiceInfo(ServiceHost host)
        {
            Console.WriteLine($"{host.Description.ServiceType} is up and running with these endpoints:");
            foreach (var endpoints in host.Description.Endpoints)
            {
                Console.WriteLine($"{endpoints.Address}");
            }
        }
    }
}
