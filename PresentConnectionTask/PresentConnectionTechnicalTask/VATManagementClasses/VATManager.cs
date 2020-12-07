using PresentConnectionTechnicalTask.Implementations;
using PresentConnectionTechnicalTask.Interfaces;
using PresentConnectionTechnicalTask.ParticipantClasses;
using PresentConnectionTechnicalTask.ParticipantClasses.ConcreteParticipants;

namespace PresentConnectionTechnicalTask.OrderManagementClasses
{
    public class VATManager
    {
        IParticipantValidator participantValidator;

        public VATManager()
        {
            participantValidator = new ParticipantValidator();
        }

        public VATManager(IParticipantValidator participantValidator)
        {
            this.participantValidator = participantValidator;
        }

        public double GetAppropriateVAT(ServiceProvider provider, Client client)
        {
            double appropriateVAT = 0;

            if (participantValidator.ParticipantIsVATPayer(provider)
                && !participantValidator.ParticipantsAreFromTheSameCountry(client, provider)
                && !participantValidator.ParticipantIsVATPayer(client) 
                && participantValidator.ParticipantLivesInEU(client))
            {
                appropriateVAT = client.Country.VATRate;
            }
            else if (participantValidator.ParticipantIsVATPayer(provider)
                && participantValidator.ParticipantsAreFromTheSameCountry(client, provider))
            {
                appropriateVAT = client.Country.VATRate;
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
