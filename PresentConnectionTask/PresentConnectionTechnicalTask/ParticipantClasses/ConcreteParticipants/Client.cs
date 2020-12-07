using PresentConnectionTechnicalTask.CountryClasses;

namespace PresentConnectionTechnicalTask.ParticipantClasses.ConcreteParticipants
{
    public class Client : Participant
    {
        public Client() : base() { }

        public Client(string name, Country country, bool isVATPayer, PersonType personType) 
            : base(name, country, isVATPayer, personType)
        {
        }      
    }
}
