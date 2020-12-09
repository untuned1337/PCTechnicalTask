using PresentConnectionTechnicalTask.CountryClasses;

namespace PresentConnectionTechnicalTask.ParticipantClasses.ConcreteParticipants
{
    public class Client : Participant
    {
        public Client() : base() { }

        public Client(string name, string countryCode, bool isVATPayer, PersonType personType) 
            : base(name, countryCode, isVATPayer, personType)
        {
        }      
    }
}
