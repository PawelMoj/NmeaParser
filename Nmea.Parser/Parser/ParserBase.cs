using Autocomp.Nmea.Common;
using Nmea.Parser.Exceptions;
using Nmea.Parser.SentenceFormatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nmea.Parser.Parser
{
    public class ParserBase : IParserBase
    {
        public SentenceFormatterBase Parse(string message)
        {
            var nmea = NmeaMessage.FromString(message);

            // Dwa pierwsze znaki lub jeden to typ urzadzenia a potem dopiero nasz naglowek
            string actualFormat = nmea.Header.Substring(nmea.Header.Length - 3);
            var type = GetSentenceType(actualFormat);
            if(type == null)
            {
                throw new NotExistingTypeException(actualFormat);
            }
            type.ParseData(nmea.Fields);

            return type;
        }

        public static SentenceFormatterBase GetSentenceType(string format)
        {
            string fullClassName = "Nmea.Parser.SentenceFormatters." + format;

            Type messageType = Type.GetType(fullClassName);

            if (messageType != null && messageType.IsSubclassOf(typeof(SentenceFormatterBase)))
            {
                var messageInstance = (SentenceFormatterBase)Activator.CreateInstance(messageType);

                return messageInstance;
            }

            return null;
        }
    }
}
