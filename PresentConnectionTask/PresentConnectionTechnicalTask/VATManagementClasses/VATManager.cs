using PresentConnectionTechnicalTask.CountryClasses;
using PresentConnectionTechnicalTask.Implementations;
using PresentConnectionTechnicalTask.Interfaces;
using PresentConnectionTechnicalTask.ParticipantClasses;
using PresentConnectionTechnicalTask.ParticipantClasses.ConcreteParticipants;

namespace PresentConnectionTechnicalTask.OrderManagementClasses
{
    public class VATManager
    {
        IParticipantValidator participantValidator;
        CountryManager countryManager;

        public VATManager()
        {
            participantValidator = new ParticipantValidator();
            countryManager = CountryManager.GetInstance();
        }

        public VATManager(IParticipantValidator participantValidator)
        {
            this.participantValidator = participantValidator;
            countryManager = CountryManager.GetInstance();

        }

        public double GetAppropriateVAT(ServiceProvider provider, Client client)
        {
            double appropriateVAT = 0;

            if (participantValidator.ParticipantIsVATPayer(provider)
                && !participantValidator.ParticipantsAreFromTheSameCountry(client, provider)
                && !participantValidator.ParticipantIsVATPayer(client) 
                && participantValidator.ParticipantLivesInEU(client))
            {                
                appropriateVAT = countryManager.GetVATRateByCountryCode(client.CountryCode);
            }
            else if (participantValidator.ParticipantIsVATPayer(provider)
                && participantValidator.ParticipantsAreFromTheSameCountry(client, provider))
            {
                appropriateVAT = countryManager.GetVATRateByCountryCode(client.CountryCode);
            }

            return appropriateVAT;
        }        
       
        public double ApplyVATToPrice(double VATRate, double price)
        {
            double priceAfterVAT = price + (price * VATRate / 100);

            return priceAfterVAT;
        }       
    }
}
