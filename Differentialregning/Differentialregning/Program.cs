using System;
using NCalc;

namespace NewtonRaphson
{
    class Program
    {
        static double EvaluateFunction(string expression, double x)
        {
            // Erstat ** med ^
            expression = expression.Replace("**", "^");

            Expression expr = new Expression(expression.Replace("x", x.ToString()));
            return Convert.ToDouble(expr.Evaluate(), System.Globalization.CultureInfo.InvariantCulture);
        }

        static double EvaluateDerivative(string expression, double x)
        {
            // Erstat ** med ^
            expression = expression.Replace("**", "^");

            double h = 0.0001;
            Expression expr = new Expression(expression.Replace("x", (x + h).ToString()));
            double fx_plus_h = Convert.ToDouble(expr.Evaluate(), System.Globalization.CultureInfo.InvariantCulture);
            expr = new Expression(expression.Replace("x", (x - h).ToString()));
            double fx_minus_h = Convert.ToDouble(expr.Evaluate(), System.Globalization.CultureInfo.InvariantCulture);
            return (fx_plus_h - fx_minus_h) / (2 * h);
        }

        static Tuple<double, int> NewtonRaphson(string function, string derivative, double x0, double epsilon = 0.005, int maxIterations = 1000)
        {
            double x = x0;
            int iterations = 0;
            while (true)
            {
                double fx0 = EvaluateFunction(function, x);
                double dfx0 = EvaluateDerivative(derivative, x);

                // Tjek for division med nul
                if (Math.Abs(dfx0) < 1e-10)
                {
                    Console.WriteLine("Advarsel: Den afledte funktion er tæt på nul. Justerer...");
                    dfx0 = 1e-10;
                }

                double nextX = x - fx0 / dfx0;
                iterations++;
                if (Math.Abs(fx0) < epsilon || iterations >= maxIterations)
                {
                    return Tuple.Create(nextX, iterations);
                }
                x = nextX;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til Differentiation og Newton-Raphson Metoden!");

            // Input funktionen (f(x))
            Console.Write("Indtast din funktion (f(x)): ");
            string function = Console.ReadLine();

            // Input den afledte funktion (f'(x))
            Console.Write("Indtast den afledte funktion (f'(x)): ");
            string derivative = Console.ReadLine();

            // Input startgæt (x0)
            Console.Write("Indtast startgæt (x0): ");
            double x0 = Convert.ToDouble(Console.ReadLine());

            // Udfør Newton-Raphson iteration
            var result = NewtonRaphson(function, derivative, x0);
            double root = result.Item1;
            int iterations = result.Item2;

            // Udskriv resultatet
            Console.WriteLine($"Rod af funktionen: {root}");
            Console.WriteLine($"Antal iterationer: {iterations}");
        }
    }
}
