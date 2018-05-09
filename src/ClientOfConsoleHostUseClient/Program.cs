using ClientOfConsoleHostUseClient.InvoiceServiceReference;
using System;

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
            var client = new InvoiceServiceClient("WSHttpBinding_IInvoiceService");
            
            var invoice = new Invoice
            {
                CustomerId = Guid.NewGuid().ToString(),
                InvoiceDate = DateTime.Now.AddHours(-1)
            };

            var invoice2 = new Invoice
            {
                CustomerId = Guid.NewGuid().ToString(),
                InvoiceDate = DateTime.Now
            };

            await client.SubmitInvocieAsync(invoice);
            await client.SubmitInvocieAsync(invoice2);

            var response = await client.GetInvoicesAsync();

            foreach (var inv in response)
            {
                Console.WriteLine(inv.CustomerId);
            }

            client.Close();
        }
    }
}
