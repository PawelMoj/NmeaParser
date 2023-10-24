using Nmea.Parser.SentenceFormatters;

namespace Nmea.Parser.Parser
{
    public interface IParserBase
    {
        SentenceFormatterBase Parse(string message);
    }
}
