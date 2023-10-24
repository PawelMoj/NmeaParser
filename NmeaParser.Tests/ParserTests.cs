using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nmea.Parser.Parser;
using Nmea.Parser.SentenceFormatters;
using System;

namespace NmeaParser.Tests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void TestGLLParsers()
        {
            string nmeaSentence = "$LCGLL,4728.31,N,12254.25,W,091342,A,A*4C<CR><LF>"; // The NMEA GLL sentence to test

            var gllParser = new ParserBase().Parse(nmeaSentence) as GLL;

            Assert.AreEqual(47.471833, gllParser.Latitude, 0.000001);
            Assert.AreEqual(-122.904167, gllParser.Longitude, 0.000001);
            Assert.AreEqual(new TimeSpan(9, 13, 42), gllParser.UTCTimeSpan);
            Assert.IsTrue(gllParser.Status);
            Assert.AreEqual(GLL.Mode.Autonomous, gllParser.ModeIndicator);

        }
        [TestMethod]
        public void TestMWVParser()
        {
            string nmeaSentence = "$WIMWV,045.0,R,12.3,N,A*3C<CR><LF>";

            var mwvParser = new ParserBase().Parse(nmeaSentence) as MWV;

            // Assert
            Assert.AreEqual(45.0, mwvParser.WindAngle, 0.001);
            Assert.AreEqual("R", mwvParser.Reference);
            Assert.AreEqual(12.3, mwvParser.WindSpeed, 0.001);
            Assert.AreEqual("N", mwvParser.WindSpeedUnit);
        }
    }

}
