using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    public abstract class ParametrizedFilter<TParametrs>: IFilter
        where TParametrs : IParameters, new ()
    {
        public ParameterInfo[] GetParameters()
        {
            return new TParametrs().GetDiscription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parameters = new TParametrs();
            parameters.SetValues(values);
            return Process(original, parameters);
        }
        public abstract Photo Process(Photo original, TParametrs parameters);
    }
}
