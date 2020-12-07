using PresentConnectionTechnicalTask.CountryClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentConnectionTechnicalTask.ParticipantClasses
{
    public class Participant
    {
        public readonly string Name;
        public readonly Country Country;
        public readonly bool IsVATPayer;
        public readonly PersonType PersonType;

        protected Participant(string name, Country country, bool isVATPayer, PersonType personType)
        {
            Name = name;
            Country = country;
            IsVATPayer = isVATPayer;
            PersonType = personType;
        }

        protected Participant() { }
    }
}
