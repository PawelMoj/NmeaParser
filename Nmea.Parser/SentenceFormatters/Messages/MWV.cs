using Nmea.Parser.CustomAttributes;

namespace Nmea.Parser.SentenceFormatters
{
    public class MWV : SentenceFormatterBase
    {
        public override int PropertiesCount => 5;
        public override void ParseData(string[] fields)
        {
            base.ParseData(fields);

            WindAngle = StringToDouble(fields[0]);
            Reference = fields[1];
            WindSpeed = StringToDouble(fields[2]);
            WindSpeedUnit = fields[3];
            
        }
        [PhysicallProperty("Wind Angle is :")]
        public double WindAngle { get; set; }

        [PhysicallProperty("Wind Speed is :")]
        public double WindSpeed { get; set; }

        public string Reference {  get; set; }
        public string WindSpeedUnit { get; set; }
        public string Status {  get; set; }

    }
}
