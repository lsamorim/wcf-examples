using System;
using System.Threading.Tasks;
using Client.HelloWorldServiceReference;
using Client.InvoiceServiceReference;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
            Console.ReadLine();
        }

        private static async void Execute()
        {
            var hwClient = new HelloWorldClient("NetTcpBinding_IHelloWorld");
            var invoiceClient = new InvoiceServiceClient("BasicHttpBinding_IInvoiceService");

            var person = new Person
            {
                FirstName = "Lucas",
                LastName = "Amorim"
            };

            var responseHello = await hwClient.SayHelloAsync(person);
            Console.WriteLine(responseHello);

            var responseBye = await hwClient.SayByeAsync(person);
            Console.WriteLine(responseBye);

            var invoice = new Invoice
            {
                CustomerId = "cus_AAA",
                InvoiceDate = DateTime.Now
            };

            await invoiceClient.SubmitInvocieAsync(invoice);
            Console.WriteLine("Invoice submmitted");

            var responseGetInvoices = await invoiceClient.GetInvoicesAsync();

            foreach (var item in responseGetInvoices)
            {
                Console.WriteLine(item.CustomerId + " " + item.InvoiceDate + " " + item.ExtensionData);
            }
            
        }
    }
}
