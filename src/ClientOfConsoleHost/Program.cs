using ClientOfConsoleHostFactoryChannel.InvoiceServiceReference;
using System;
using System.ServiceModel;

namespace ClientOfConsoleHostFactoryChannel
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
            var factory = new ChannelFactory<IInvoiceServiceChannel>("WSHttpBinding_IInvoiceService");

            IInvoiceServiceChannel channel = factory.CreateChannel();

            var invoice = new Invoice
            {
                CustomerId = Guid.NewGuid().ToString(), InvoiceDate = DateTime.Now.AddHours(-1)
            };

            var invoice2 = new Invoice
            {
                CustomerId = Guid.NewGuid().ToString(),
                InvoiceDate = DateTime.Now
            };

            await channel.SubmitInvocieAsync(invoice);
            await channel.SubmitInvocieAsync(invoice2);

            var response = await channel.GetInvoicesAsync();

            foreach (var inv in response)
            {
                Console.WriteLine(inv.CustomerId);
            }

            channel.Close();
        }
    }
}
