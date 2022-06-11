using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public struct Pixel
    {
        private double r;
        private double g;
        private double b;
        private double Check(double value)
        {
            if (value < 0 || value > 1)
                throw new ArgumentException("Only allow value >0 and <1");
            return value;
        }

        public Pixel(double R = 0, double G = 0, double B = 0)
        {
            r = g = b = 0;
            this.R = R;
            this.G = G;
            this.B = B;
        }
        public static double Trim(double value)
        {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }
        public double R
        {
            get
            {
                return r;
            }
            set
            {
                r = Check(value);
            }
        }
        public double G
        {
            get
            {
                return g;
            }
            set
            {
                g = Check(value);
            }
        }
        public double B
        {
            get
            {
                return b;
            }
            set
            {
                b = Check(value);
            }
        }

        public static Pixel operator *(Pixel pixel,double value) =>
            new Pixel(Pixel.Trim(pixel.R * value),
                    Pixel.Trim(pixel.G * value),
                    Pixel.Trim(pixel.B * value));

        public static Pixel operator *(double value, Pixel pixel) =>
           pixel * value;
    }
}
