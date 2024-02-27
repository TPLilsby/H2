using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class Rectangle : Parallelogram
    {
        private static double angle = 90;

        public Rectangle(double b, double a) : base(b, a, angle) 
        {
            _b = b;
            _a = a;
        }


        public override double Area()
        {
            return Math.Round(_a * _b, 3);
        }

        public override double Perimeter()
        {
            return Math.Round(2 * (_a + _b), 3);
        }
    }
}
