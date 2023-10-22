using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    public class EmptyParametrs : IParameters
    {
        public double Coefficient { get; set; }
        public ParameterInfo[] GetDiscription()
        {
            return new ParameterInfo[0];
        }

        public void SetValues(double[] values)
        {
        }
    }
}
