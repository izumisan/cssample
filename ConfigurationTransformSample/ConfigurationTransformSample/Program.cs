using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace ConfigurationTransformSample
{
    class Program
    {
        static void Main( string[] args )
        {
            var appSettings = ConfigurationManager.AppSettings;
            foreach ( string key in appSettings.Keys )
            {
                Console.WriteLine( $@"key={key}, value={appSettings[key]}" );
            }

            Console.WriteLine();
            Console.WriteLine( @"Please enter key." );
            Console.ReadLine();
        }
    }
}
