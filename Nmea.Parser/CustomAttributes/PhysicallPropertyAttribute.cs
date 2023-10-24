using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nmea.Parser.CustomAttributes
{
    public class PhysicallPropertyAttribute : Attribute
    {
        public string Message { get; }

        public PhysicallPropertyAttribute(string message)
        {
            Message = message;
        }
    }
}
