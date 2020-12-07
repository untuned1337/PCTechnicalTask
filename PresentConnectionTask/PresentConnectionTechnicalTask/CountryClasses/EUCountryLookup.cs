using PresentConnectionTechnicalTask.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentConnectionTechnicalTask.CountryClasses
{
    public class EUCountryLookup
    {
        private static EUCountryLookup _instance;
        private static Dictionary<string, double> VATRateByCountryCode;

        public static EUCountryLookup GetInstance()
        {
            if (_instance == null)
            {
                _instance = new EUCountryLookup();
            }
            return _instance;
        }

        private EUCountryLookup()
        {
            VATRateByCountryCode = new Dictionary<string, double>()
            {
                { "BE", 21 },
                { "BG", 20 },
                { "CZ", 21 },
                { "DK", 21 },
                { "DE", 20 },
                { "EE", 21 },
                { "IE", 21 },
                { "EL", 20 },
                { "ES", 21 },
                { "FR", 21 },
                { "HR", 20 },
                { "IT", 21 },
                { "CY", 21 },
                { "LV", 20 },
                { "LT", 21 },
                { "LU", 21 },
                { "HU", 20 },
                { "MT", 21 },
                { "NL", 21 },
                { "AT", 20 },
                { "PL", 21 },
                { "PT", 21 },
                { "RO", 20 },
                { "SI", 21 },                
                { "SK", 20 },
                { "FI", 21 },
                { "SE", 21 },
                { "UK", 20 }
            };
        }
        
        public double GetVATRateByCountryCode(string countryCode)
        {
            if (CountryIsEUCountry(countryCode))
            {
                return VATRateByCountryCode[countryCode];
            }
            else
            {
                throw new CountryIsNotInEUException();
            }           
        }

        public bool CountryIsEUCountry(string countryCode)
        {
            if (VATRateByCountryCode.ContainsKey(countryCode))
            {
                return true;
            }
            return false;
        }
    }
}
