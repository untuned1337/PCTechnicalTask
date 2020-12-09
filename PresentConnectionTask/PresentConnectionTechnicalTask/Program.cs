using PresentConnectionTechnicalTask.CountryClasses;
using PresentConnectionTechnicalTask.CustomExceptions;
using PresentConnectionTechnicalTask.ParticipantClasses.ConcreteParticipants;
using System;

namespace PresentConnectionTechnicalTask
{
    class Program
    {
        static void Main(string[] args)
        {                     
            Client client = new Client
                (
                    name:"Jonas", 
                    countryCode: "LT",
                    isVATPayer:false,
                    personType:PersonType.IndividualPerson
                );

            Service service = new Service("WebSite Hosting", servicePrice:25);
            ServiceProvider provider = 
                new ServiceProvider
                (
                    name:"PresentConnection",
                    countryCode: "UK",
                    service:service,
                    isVATPayer:true
                );

            provider.WriteBillToClient(client);           

            Console.ReadKey();
        }
    }
}
