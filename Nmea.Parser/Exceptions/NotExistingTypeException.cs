using System;

namespace Nmea.Parser.Exceptions
{
    public class NotExistingTypeException : Exception
    {
        public NotExistingTypeException(string type) : base(string.Format("Invalid type of message: {0}", type))
        { 
        }
    }
}
