using PresentConnectionTechnicalTask.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentConnectionTechnicalTask.CountryClasses
{
    public class Country
    {
        public readonly string CountryCode;
        public readonly double VATRate;
        public readonly bool IsInEU;

        public Country()
        {
        }

        public Country(string countryCode, double vatRate, bool isInEU)
        {
            CountryCode = countryCode;
            VATRate = vatRate;
            IsInEU = isInEU;
        }
    }
}
