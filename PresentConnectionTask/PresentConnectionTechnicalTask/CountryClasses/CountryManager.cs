using PresentConnectionTechnicalTask.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentConnectionTechnicalTask.CountryClasses
{
    public static class CountryManager
    {
        public static Country GetCountryByCountryCode(string countryCode)
        {
            double VATRate;
            bool IsInEU;
            try
            {
                EUCountryLookup euCountryLookup = EUCountryLookup.GetInstance();
                VATRate = euCountryLookup.GetVATRateByCountryCode(countryCode);
                IsInEU = true;
            }
            catch (CountryIsNotInEUException)
            {
                VATRate = 0;
                IsInEU = false;
            }

            Country country = new Country(countryCode, VATRate, IsInEU);

            return country;
        }
    }
}
