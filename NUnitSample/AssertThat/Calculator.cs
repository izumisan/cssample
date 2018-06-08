using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssertThat
{
    public class Calculator
    {
        public Calculator()
        {
        }

        public static double sum( double a, double b )
        {
            return a + b;
        }

        public static double div( double a, double b )
        {
            if ( b != 0.0 )
            {
                return a / b;
            }
            else
            {
                throw new DivideByZeroException( "error" );
            }
        }
    }
}
