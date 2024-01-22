
class Program
{
    static void Main(string[] args)
    {
        Thread printThread = new Thread(PrintOutput);

        Thread readThread = new Thread(ReadInput);

        printThread.Start();
        readThread.Start();

    }

    static char ReadInput()
    {
        char input = char.Parse(Console.ReadLine());


        Console.ReadKey();
        return input;
    }

    static void PrintOutput(char input)
    {
        Console.WriteLine();
    }
}