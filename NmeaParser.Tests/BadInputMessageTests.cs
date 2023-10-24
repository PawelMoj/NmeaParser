using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nmea.Parser.Exceptions;
using Nmea.Parser.Parser;
using Nmea.Parser.SentenceFormatters;

namespace NmeaParser.Tests
{
    [TestClass]
    public class BadInputMessageTests
    {
        [TestMethod]
        [ExpectedException(typeof(BadArgumentsException))]
        public void TooManyInputArgumentTest()
        {
            string nmeaSentence = "$LCGLL,4728.31,N,12254.25,W,091342,A,A,B,YT,2na10*4C<CR><LF>"; // The NMEA GLL sentence to test

            var parser = new ParserBase().Parse(nmeaSentence);
        }

        [TestMethod]
        public void NotEnoughInputArgumentsTest()
        {
            string nmeaSentence = "$LCGLL,4728.31,N,12254.25,W,091342*4C<CR><LF>"; // The NMEA GLL sentence to test

            Assert.ThrowsException<BadArgumentsException>(() => new ParserBase().Parse(nmeaSentence));
        }

        [TestMethod]
        public void WrongArgsTypeTest()
        {
            string nmeaSentence = "$WIMWV,045.0,R,nicDoTestu,N,A*3C<CR><LF>"; // The NMEA GLL sentence to test

            Assert.ThrowsException<BadInputException>(() => new ParserBase().Parse(nmeaSentence));
        }

    }

}
