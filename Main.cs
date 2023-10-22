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
				"����������/����������",
				(pixel,parameters)=>pixel*parameters.Coefficient
				));
			window.AddFilter(new PixelFilter<EmptyParametrs>(
				"������� ������",
				(pixel, parameters) => {
					var average = pixel.B * 0.0722 + pixel.R * 0.2126 + pixel.G * 0.7152;
					return new Pixel(average, average, average);
					}
				));

            window.AddFilter(new TransformFilter(
                "�������� �� �����������",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, point.Y)
                ));

            window.AddFilter(new TransformFilter(
                "������� ������ ������� �������",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(point.Y, point.X)
                ));

            window.AddFilter(new TransformFilter<RotationParameters>(
				"��������� ��������", new RotateTransformer()));
			Application.Run (window);
		}
	}
}
