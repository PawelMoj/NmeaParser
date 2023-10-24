using Nmea.Parser.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nmea.Parser.SentenceFormatters
{
    public class GLL : SentenceFormatterBase
    {
        //This property should be checked and properlly adjust according to Nmea documentation
        public override int PropertiesCount => 7;
        public override void ParseData(string[] fields)
        {
            base.ParseData(fields);

            Latitude = StringToLatitude(fields[0], fields[1]);
            Longitude = StringToLongitude(fields[2], fields[3]);
            UTCTimeSpan = StringToTimeSpan(fields[4]);
            Status = fields[5] == "A" ? true : false;
            switch (fields[6])
            {
                case "A": 
                    ModeIndicator = Mode.Autonomous; 
                    break;
                case "D": 
                    ModeIndicator = Mode.DataNotValid; 
                    break;
                case "E": 
                    ModeIndicator = Mode.EstimatedDeadReckoning; 
                    break;
                case "M": 
                    ModeIndicator = Mode.Manual; 
                    break;
                case "S": 
                    ModeIndicator = Mode.Simulator; 
                    break;
                case "N": 
                    ModeIndicator = Mode.DataNotValid; 
                    break;
            }
        }

        [PhysicallProperty("Lattitude cords (minus means South Direction)")]
        public double Latitude { get; private set; }
        [PhysicallProperty("Longitude cords (minus means West Direction)")]
        public double Longitude { get; private set; }
        [PhysicallProperty("Time of position fix ")]
        public TimeSpan UTCTimeSpan { get; private set; }
        public bool Status { get; private set; }
        public Mode ModeIndicator { get; private set; }

        public enum Mode
        { 
            Autonomous,
            Differential,
            EstimatedDeadReckoning,
            Manual,
            Simulator,
            DataNotValid
        }

    }
}
