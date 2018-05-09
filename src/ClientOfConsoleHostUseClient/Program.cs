using ClientOfConsoleHostUseClient.InvoiceServiceReference;
using System;
using System.ServiceModel;

namespace ClientOfConsoleHostUseClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();

            Console.ReadKey();
        }

        private static async void Execute()
        {
            var client = new InvoiceServiceClient("NetTcp_IInvoiceService");

            try
            {
                var invoice = new Invoice
                {
                    CustomerId = "fault" + Guid.NewGuid().ToString(),
                    InvoiceDate = DateTime.Now.AddHours(-1)
                };

                var invoice2 = new Invoice
                {
                    CustomerId = Guid.NewGuid().ToString(),
                    InvoiceDate = DateTime.Now
                };

                await client.SubmitInvoiceAsync(invoice);
                await client.SubmitInvoiceAsync(invoice2);

                var response = await client.GetInvoicesAsync();

                foreach (var inv in response)
                {
                    Console.WriteLine(inv.CustomerId);
                }

                client.Close();
            }
            catch(FaultException fe)
            {
                Console.WriteLine($"FaultException: {fe.GetType()}");
                client.Abort();
            }
            catch(CommunicationException ce)
            {
                Console.WriteLine($"FaultException: {ce.GetType()}");
                client.Abort();
            }
            catch(TimeoutException te)
            {
                Console.WriteLine($"FaultException: {te.GetType()}");
                client.Abort();
            }
        }
    }
}
