using System;
using System.Collections.Generic;
using System.Text;

namespace PresentConnectionTechnicalTask.CustomExceptions
{
    public class CountryIsNotInEUException : Exception
    {
        public CountryIsNotInEUException()
        {
        }

        public CountryIsNotInEUException(string message)
            : base(message)
        {
        }

        public CountryIsNotInEUException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
