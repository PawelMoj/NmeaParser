using Nmea.Parser.CustomAttributes;
using Nmea.Parser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nmea.ConsoleApp
{
    public class Program
    {
        private string sampleNmea = "$LCGLL,4728.31,N,12254.25,W,091342,A,A*4C<CR><LF>";
        static void Main(string[] args)
        {
            Console.WriteLine("Provide your Nmea message: \n");
            var message = Console.ReadLine();
            Console.WriteLine("\n");
            try
            {
                var parser = new ParserBase().Parse(message);
                Type type = parser.GetType();
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    var printAttribute = property.GetCustomAttribute(typeof(PhysicallPropertyAttribute)) as PhysicallPropertyAttribute;
                    if (printAttribute != null)
                    {
                        string propertyMessage = printAttribute.Message;
                        object propertyValue = property.GetValue(parser);

                        Console.WriteLine($"{propertyMessage}: {propertyValue}");
                        Console.WriteLine("\n");
                    }
                    //else do nothing
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("ups something went wrong exception: {0}", ex.Message));
            }
            Console.WriteLine("press any button to close this window");
            Console.ReadKey();
        }
    }
}
