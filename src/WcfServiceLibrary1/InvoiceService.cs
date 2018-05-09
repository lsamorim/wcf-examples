using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;

namespace WcfServiceLibrary1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class InvoiceService : IInvoiceService
    {
        private List<Invoice> invoices = new List<Invoice>()
        {
            new Invoice
            {
                CustomerId = "cus_123",
                InvoiceDate = new System.DateTime(2018, 01, 01),
                SomePrivateInfo = "AAA"
            },
            new Invoice
            {
                CustomerId = "cus_456",
                InvoiceDate = new System.DateTime(2018, 02, 02),
                SomePrivateInfo = "BBB"
            },
            new Invoice
            {
                CustomerId = "cus_789",
                InvoiceDate = new System.DateTime(2018, 03, 03),
                SomePrivateInfo = "CCC"
            }
        };

        public void SubmitInvoice(Invoice invoice)
        {
            if (invoice.CustomerId.Contains("fault"))
                throw new FaultException("Error within SubmitInvoice");

            if (invoice.CustomerId.Contains("timeout"))
                Thread.Sleep(TimeSpan.FromSeconds(120));

            invoices.Add(invoice);
        }

        public int GetStatus(Invoice invoice)
        {
            return 1;
        }

        public List<Invoice> GetInvoices()
        {
            return invoices;
        }

        public void CancelInvoice(Invoice invoice)
        {

        }
    }
}
