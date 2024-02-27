using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometri
{
    public class QL
    {
        protected double _a = 0;
        protected double _b = 0;
        protected double _c = 0;
        protected double _d = 0;
        protected double _angle = 0;

        public QL (double a, double b, double c, double d, double angle)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _angle = angle;
        }

        public virtual double Area()
        {
            /* Virker ikke
            
            // Beregne diagonal
            double tal1d1 = _a*_a + _b*_b;

            double tal2d1 = 2 * _a * _b;

            double tal3d1 = Math.Cos(_angle);

            double tal4d1 = (tal1d1 - tal2d1) * tal3d1;

            double diagonal1 = Math.Sqrt(tal4d1);
            Console.WriteLine("Dia " + diagonal1);

            // Trekant ACB
            // Udregn s trekant 1
            double s1 = (_b + diagonal1 + _a) / 2;
            Console.WriteLine("S1 " + s1);

            double tal1Trekant1 = s1 * (s1 - _b);

            double tal2Trekant1 = s1 - diagonal1;

            double tal3Trekant1 = s1 - _a;

            double tal4Trekant1 = tal1Trekant1 * tal2Trekant1 * tal3Trekant1;

            double sqrt = Math.Sqrt(tal4Trekant1);

            // Areal trekant 1
            double area1 = sqrt;
            Console.WriteLine("Arreal1 " + area1);

            // Trekant ADC
            double s2 = (_c + _d + diagonal1) / 2;
            Console.WriteLine("S2 " + s2);

            double tal1Trekant2 = s2 * (s2 - _c) * (s2 - _d) * (s2 - diagonal1);

            Console.WriteLine("tal4Trekant2 trekant 2 " + tal1Trekant2);

            double sqrt2 = Math.Sqrt(tal1Trekant2);

            // Areal trekant 2
            double area2 = sqrt2;
            Console.WriteLine("Areal2 " + area2);

            double result = area1 + area2;
            Console.WriteLine("Result " + result);
            */
            return 0;
        }
        public virtual double Perimeter()
        {
            return _a + _b + _c + _d;
        }
    }
}
