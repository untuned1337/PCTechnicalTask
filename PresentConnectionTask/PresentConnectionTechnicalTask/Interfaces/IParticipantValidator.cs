using PresentConnectionTechnicalTask.ParticipantClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentConnectionTechnicalTask.Interfaces
{
    public interface IParticipantValidator
    {
        bool ParticipantLivesInEU(Participant participant);
        bool ParticipantIsVATPayer(Participant participant);
        bool ParticipantsAreFromTheSameCountry(Participant participantA, Participant participantB);        
    }
}
