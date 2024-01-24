class Program
{
    static char[] values = new char[3];
    static void Main(string[] args)
    {

        Thread getInputThread = new Thread(GetInput);
        getInputThread.Start();

        Thread writeOutputThread = new Thread(WriteOutput);

        writeOutputThread.Start();

        getInputThread.Join();
    }

    static void GetInput()
    {
        Console.WriteLine("Skriv tegn");
        char input = char.Parse(Console.ReadLine());

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = input;
        }
    }

    static void WriteOutput()
    {
        for (int i = 0; i < values.Length; i++)
        {
            Console.Write(values[i]);
        }
    }
}
