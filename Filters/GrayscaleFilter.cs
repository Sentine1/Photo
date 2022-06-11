using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//var average = original[x, y].B * 0.0722 + original[x, y].R * 0.2126 + original[x, y].G * 0.7152;

namespace MyPhotoshop
{
    public class GrayscaleFilter : PixelFilter
    {
        public GrayscaleFilter() : base(new EmptyParametrs()) { }
        public override Pixel ProcessPixel(Pixel pixel, IParameters parameters)
        {
            var average = pixel.B * 0.0722 + pixel.R * 0.2126 + pixel.G * 0.7152;
            return new Pixel(average, average, average);
        }

        public override string ToString()
        {
            return "Фильтр серого";
        }

    }
}
