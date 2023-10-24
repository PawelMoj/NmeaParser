using Nmea.Parser.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nmea.Parser.SentenceFormatters
{
    //Tak jest nazwana cała sekcja o komunikatach w dokumentacji: 
    // TABLE 5 - APPROVED SENTENCE FORMATTERS (Parametric followed by Encapsulation)
    public abstract class SentenceFormatterBase
    {
        abstract public int PropertiesCount { get; }
        public virtual void ParseData(string[] fields)
        {
            if (fields.Length != PropertiesCount)
            {
                if (fields.Length > PropertiesCount)
                {
                    throw new BadArgumentsException(string.Format("Too many fields in Nmea sentence, expected {0} but got {1}", PropertiesCount, fields.Length));
                }
                else
                {
                    throw new BadArgumentsException(string.Format("Not enough fields in Nmea sentence, expected {0} but got {1}", PropertiesCount, fields.Length));
                }
            }
        }

        internal static double StringToLatitude(string value, string ns)
        {
            if (value == null || value.Length < 3)
                throw new BadInputException("Wrong type of lattitude");
            double latitude = int.Parse(value.Substring(0, 2), CultureInfo.InvariantCulture) + double.Parse(value.Substring(2), CultureInfo.InvariantCulture) / 60;
            if (ns == "S")
                latitude *= -1;
            return latitude;
        }

        internal static double StringToLongitude(string value, string ew)
        {
            if (value == null || value.Length < 4)
                throw new BadInputException("Wrong type of longitude");
            double longitude = int.Parse(value.Substring(0, 3), CultureInfo.InvariantCulture) + double.Parse(value.Substring(3), CultureInfo.InvariantCulture) / 60;
            if (ew == "W")
                longitude *= -1;
            return longitude;
        }

        internal static double StringToDouble(string value)
        {
            if (value != null && double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }
            throw new BadInputException("Wrong type of what is expected to be a number");
        }

        internal static TimeSpan StringToTimeSpan(string value)
        {
            if (value != null && value.Length >= 6)
            {
                return new TimeSpan(int.Parse(value.Substring(0, 2), CultureInfo.InvariantCulture),
                                   int.Parse(value.Substring(2, 2), CultureInfo.InvariantCulture), 0)
                                   .Add(TimeSpan.FromSeconds(double.Parse(value.Substring(4), CultureInfo.InvariantCulture)));
            }
            throw new BadInputException("Wrong type of what is expected to be a time value");
        }
    }
}
