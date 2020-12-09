using PresentConnectionTechnicalTask.CountryClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentConnectionTechnicalTask.ParticipantClasses
{
    public class Participant
    {
        public readonly string Name;
        public readonly string CountryCode;
        public readonly bool IsVATPayer; 
        public readonly PersonType PersonType;

        protected Participant(string name, string countryCode, bool isVATPayer, PersonType personType)
        {
            Name = name;
            CountryCode = countryCode;
            IsVATPayer = isVATPayer;
            PersonType = personType;
        }

        protected Participant() { }
    }
}
