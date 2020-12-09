using PresentConnectionTechnicalTask.CountryClasses;
using PresentConnectionTechnicalTask.OrderManagementClasses;

namespace PresentConnectionTechnicalTask.ParticipantClasses.ConcreteParticipants
{
    public class ServiceProvider : Participant
    {
        public Service Service { get; set; }

        public ServiceProvider(string name, string countryCode, Service service, bool isVATPayer) 
            : base(name, countryCode, isVATPayer, PersonType.LegalPerson)
        {
            Service = service;
        }

        public ServiceProvider() : base()
        {
        }

        public void WriteBillToClient(Client client)
        {
            VATManager vatManager = new VATManager();
            double appropriateVAT = vatManager.GetAppropriateVAT(this, client);
            double priceAfterVAT = vatManager.ApplyVATToPrice(appropriateVAT, this.Service.ServicePrice);

            Bill bill = new Bill(client.Name, this.Name, Service, appropriateVAT, priceAfterVAT);
            BillPrinter.PrintBillToConsole(bill);
        }
    }  
}
