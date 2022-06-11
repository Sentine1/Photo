using System;

namespace MyPhotoshop
{
    public class Photo
    {
        public readonly int width;
        public readonly int height;
        private readonly Pixel[,] data;

        public Pixel this[int indexx, int indexy]
        {
            get => data[indexx, indexy];
            set => data[indexx, indexy] = value;
        }

        public Photo(int width, int height)
        {
            this.width = width;
            this.height = height;
            data = new Pixel[width, height];
        }
    }
}

