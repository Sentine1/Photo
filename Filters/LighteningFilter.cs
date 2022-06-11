using System;

namespace MyPhotoshop
{
    public class LighteningFilter : PixelFilter
    {
        public LighteningFilter() : base(new LighteningParametrs()) { }

        public override string ToString()
        {
            return "Осветление/затемнение";
        }

        public override Pixel ProcessPixel(Pixel pixel, IParameters parameters)
        {
            return pixel * (parameters as LighteningParametrs).Coefficient;
        }
    }
}

