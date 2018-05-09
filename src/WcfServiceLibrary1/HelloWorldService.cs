using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }

    [ServiceContract]
    public interface IHelloWorld
    {
        [OperationContract]
        string SayHello(Person person);

        [OperationContract]
        string SayBye(Person person);
    }

    public class HelloWorldService : IHelloWorld
    {
        public string SayHello(Person person)
        {
            return $"HELLO! First: {person.FirstName} - Last: {person.LastName}";
        }

        public string SayBye(Person person)
        {
            return $"BYE! First: {person.FirstName} - Last: {person.LastName}";
        }
    }
}
