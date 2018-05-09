using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    [DataContract]
    public class Invoice
    {
        [DataMember]
        public string CustomerId { get; set; }

        [DataMember]
        public DateTime InvoiceDate { get; set; }

        public string SomePrivateInfo { get; set; }
    }
}
