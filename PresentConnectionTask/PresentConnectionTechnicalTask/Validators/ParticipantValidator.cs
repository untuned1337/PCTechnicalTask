using PresentConnectionTechnicalTask.CountryClasses;
using PresentConnectionTechnicalTask.Interfaces;
using PresentConnectionTechnicalTask.ParticipantClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentConnectionTechnicalTask.Implementations
{
    public class ParticipantValidator : IParticipantValidator
    {
        public bool ParticipantLivesInEU(Participant participant)
        {
            CountryManager countryManager = CountryManager.GetInstance();
            string countryCode = participant.CountryCode;

            return countryManager.CountryIsEUCountry(countryCode);
        }

        public bool ParticipantIsVATPayer(Participant participant)
        {
            return participant.IsVATPayer;
        }

        public bool ParticipantsAreFromTheSameCountry(Participant participantA, Participant participantB)
        {
            return participantA.CountryCode == participantB.CountryCode;
        }
    }
}
