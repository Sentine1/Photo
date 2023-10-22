using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    public abstract class ParametrizedFilter<TParametrs>: IFilter
        where TParametrs : IParameters, new ()
    {
        IParametersHandler<TParametrs> handler = new SimpleParametersHandler<TParametrs>();
        public ParameterInfo[] GetParameters()
        {
            return handler.GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            var parameters = handler.CreateParameters(values);
            return Process(original, parameters);
        }
        public abstract Photo Process(Photo original, TParametrs parameters);
    }
}
