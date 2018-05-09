using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IInvoiceService
    {
        [OperationContract]
        void SubmitInvocie(Invoice invoice);

        [OperationContract]
        int GetStatus(Invoice invoice);

        [OperationContract]
        List<Invoice> GetInvoices();

        void CancelInvoice(Invoice invoice);
    }
}
