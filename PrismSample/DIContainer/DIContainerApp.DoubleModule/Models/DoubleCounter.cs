using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainerApp.DoubleModule.Models
{
    public class DoubleCounter : IDoubleCounter
    {
        public DoubleCounter()
        {
        }

        private double _value = 0.0;

        public double Value
        {
            get
            {
                double ret = _value;
                if ( 0.0 < _value )
                {
                    _value *= 2.0;
                }
                else
                {
                    _value = 1.0;
                }
                return ret;
            }
        }
    }
}
