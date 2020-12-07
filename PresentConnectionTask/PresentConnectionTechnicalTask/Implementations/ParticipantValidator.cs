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
            return participant.Country.IsInEU;
        }

        public bool ParticipantIsVATPayer(Participant participant)
        {
            return participant.IsVATPayer;
        }

        public bool ParticipantsAreFromTheSameCountry(Participant participantA, Participant participantB)
        {
            return participantA.Country.CountryCode == participantB.Country.CountryCode;
        }
    }
}
