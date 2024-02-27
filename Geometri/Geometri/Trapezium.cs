using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class Trapezium : QL
    {
        private static double angle = 0;

        public Trapezium(double a, double b, double c, double d) : base(a, b, c, d, angle)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }

        public double Height()
        {
            double s = (_a + _b - _c + _d)/2;

            double q = 2 / (_a - _c);

            double e = s * (s - _a + _c) * (s - _b) * (s - _d);

            double sqrt = Math.Sqrt(e);

            double result = q * sqrt;

            return result;
        }

        public override double Area()
        {
            return Math.Round(0.5 * (_a + _c) * Height(), 3);
        }

        public override double Perimeter()
        {
            return Math.Round(_a + _b + _c + _d, 3);
        }
    }
}
