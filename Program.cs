using MyPhotoshop.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiler
{
    class Program
    {
        static void Test(Func<double[],LighteningParametrs> method, int N)
        {
            var args = new double[] { 0 };
            method(args);
            var watch = new Stopwatch();
            watch.Start();
            for (var i = 0; i < N; i++)
            {
                method(args);
            }
            watch.Stop();
            Console.WriteLine(1000 * (double)watch.ElapsedMilliseconds / N);

        }
        static void Main(string[] args)
        {
            var simpleHandler = new SimpleParametersHandler<LighteningParametrs>();
            Test((values) => simpleHandler.CreateParameters(values), 100000);
            Test((values) => new LighteningParametrs { Coefficient = values[0] }, 100000);
            Console.ReadKey();
        }
    }
}
