using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nmea.Parser.Exceptions
{
    public class BadInputException : Exception
    {
        public BadInputException(string msg): base(msg) 
        { }
    }
}
