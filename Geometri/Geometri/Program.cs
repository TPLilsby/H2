
namespace Geometri
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // AL objects
            QL ql = new QL(6.4, 5, 6.4, 5, 45);

            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!" + ql.Area());
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!" + ql.Perimeter());

            // Parellelogram objects
            Parallelogram parallelogram1 = new Parallelogram(5, 6.4, 45);
            Parallelogram parallelogram2 = new Parallelogram(12, 7, 121);
            
            Console.ForegroundColor = ConsoleColor.Green;

            // Write the area and perimeter to the console
            Console.WriteLine("Area & perimeter of the Parallelograms: ");
            Console.WriteLine("Area: " + parallelogram1.Area()); // parlellogram1
            Console.WriteLine("Perimeter: " + parallelogram1.Perimeter()); // parallelogram1

            Console.WriteLine("\nArea: " + parallelogram2.Area()); // parallelogram2
            Console.WriteLine("Perimeter: " + parallelogram2.Perimeter()); // parallelogram2

            Console.ResetColor();

            // Trapezium objects
            Trapezium trapezium1 = new Trapezium(10, 9, 8, 9);
            Trapezium trapezium2 = new Trapezium(14, 13, 12, 13);

            Console.ForegroundColor = ConsoleColor.Red;

            // Write the area and perimeter to the console
            Console.WriteLine("\nArea & perimeter of the trapeziums: ");
            Console.WriteLine("Area: " + trapezium1.Area()); // trapezium1
            Console.WriteLine("Perimeter: " + trapezium1.Perimeter()); // trapezium1

            Console.WriteLine("\nArea: " + trapezium2.Area()); // trapezium2
            Console.WriteLine("Perimeter: " + trapezium2.Perimeter()); // trapezium2

            Console.ResetColor();

            // Rectangle objects
            Rectangle rectangle1 = new Rectangle(4.5, 5);
            Rectangle rectangle2 = new Rectangle(5, 10);

            Console.ForegroundColor = ConsoleColor.Blue;

            // Write the area and perimeter to the console
            Console.WriteLine("\nArea & perimeter of the rectangles: ");
            Console.WriteLine("Area: " + rectangle1.Area()); // rectangle1
            Console.WriteLine("Perimeter: " + rectangle1.Perimeter()); // rectangle1

            Console.WriteLine("\nArea: " + rectangle2.Area()); // rectangle2
            Console.WriteLine("Perimeter: " + rectangle2.Perimeter()); // rectangle2

            Console.ResetColor();

            // Square objects
            Square square1 = new Square(4.6);
            Square square2 = new Square(10);

            Console.ForegroundColor= ConsoleColor.Yellow;

            // Write the area and perimeter to the console
            Console.WriteLine("\nArea & perimeter of the squares: ");
            Console.WriteLine("Area: " + square1.Area()); // square1
            Console.WriteLine("Perimeter: " + square1.Perimeter()); // square1

            Console.WriteLine("\nArea: " + square2.Area()); // square2
            Console.WriteLine("Perimeter: " + square2.Perimeter()); // square2

            Console.ResetColor();
        }
    }
}