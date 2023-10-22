using MyPhotoshop.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MyPhotoshop.Filters
{
    public class TransformFilter<TParametrs> : ParametrizedFilter<TParametrs>
        where TParametrs :IParameters, new()
    {

        ITransformer<TParametrs> transformer;
        string name;
        public override string ToString()
        {
            return name;
        }

        public TransformFilter(string name, ITransformer<TParametrs> transformer)
        {
            this.name = name;
            this.transformer = transformer;
        }

        public override Photo Process(Photo original, TParametrs parametrs)
        {
            var oldSize = new Size(original.width, original.height);
            transformer.Prepare(oldSize, parametrs);
            var result = new Photo(transformer.ResultSize.Width, transformer.ResultSize.Height);
            for (int x = 0; x < transformer.ResultSize.Width; x++)
            {
                for (int y = 0; y < transformer.ResultSize.Height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = transformer.MapPoint(point);
                    if (oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }
            }
            return result;
        }
    }
}
