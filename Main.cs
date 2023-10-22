using MyPhotoshop.Filters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter (new PixelFilter<LighteningParametrs>(
				"Осветление/затемнение",
				(pixel,parameters)=>pixel*parameters.Coefficient
				));
			window.AddFilter(new PixelFilter<EmptyParametrs>(
				"Оттенки серого",
				(pixel, parameters) => {
					var average = pixel.B * 0.0722 + pixel.R * 0.2126 + pixel.G * 0.7152;
					return new Pixel(average, average, average);
					}
				));

            window.AddFilter(new TransformFilter(
                "Отразить по горизонтали",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, point.Y)
                ));

            window.AddFilter(new TransformFilter(
                "Поворот против часовой стрелки",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(point.Y, point.X)
                ));

            window.AddFilter(new TransformFilter<RotationParameters>(
				"Свободное вращение", new RotateTransformer()));
			Application.Run (window);
		}
	}
}
