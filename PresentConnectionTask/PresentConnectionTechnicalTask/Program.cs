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
                    country: CountryManager.GetCountryByCountryCode("LT"),
                    isVATPayer:false,
                    personType:PersonType.IndividualPerson
                );

            Service service = new Service("WebSite Hosting", servicePrice:25);
            ServiceProvider provider = 
                new ServiceProvider
                (
                    name:"PresentConnection",
                    service:service,
                    country:CountryManager.GetCountryByCountryCode("UK"),
                    isVATPayer:true
                );

            provider.WriteBillToClient(client);           

            Console.ReadKey();
        }
    }
}
