using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class Square : Rectangle
    {
        private static double b;

        public Square(double a) : base(b, a)
        {
            _a = a;
        }


        public override double Area()
        {
            return Math.Round(_a * _a, 3);
        }

        public override double Perimeter()
        {
            return Math.Round(4 * _a, 3);
        }
    }
}
