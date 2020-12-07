
using PresentConnectionTechnicalTask.ParticipantClasses.ConcreteParticipants;

namespace PresentConnectionTechnicalTask
{
    public class Bill
    {
        public readonly string ClientName;
        public readonly string ProviderName;
        public readonly Service Service;
        public readonly double VATRate;
        public readonly double ServicePriceAfterVAT;

        public Bill(string clientName, string providerName, Service service, double VATRate, double servicePriceAfterVAT)
        {
            ClientName = clientName;
            ProviderName = providerName;
            Service = service;
            this.VATRate = VATRate;
            ServicePriceAfterVAT = servicePriceAfterVAT;
        }                
    }
}
