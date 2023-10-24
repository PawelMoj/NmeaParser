using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nmea.Parser.Exceptions
{
    public class BadArgumentsException : Exception
    {
        public BadArgumentsException(string message) : base(message)
        {
        }
    }
}
