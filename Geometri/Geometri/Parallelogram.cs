using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class Parallelogram : QL
    {
        private static double c = 0;
        private static double d = 0;

        public Parallelogram(double b, double a, double angle) : base(a, b, c, d, angle)
        {
        }

        public override double Area()
        {
            return Math.Round(_a * _b * Math.Sin(_angle), 3);
        }

        public override double Perimeter()
        {
            return Math.Round(2 * (_a + _b), 3);
        }
    }
}
