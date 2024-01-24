
class Program
{
    static int counter = 0;
    static char input;

    static void Main(string[] args)
    {
        int count = 0;

        while (count != 10)
        {
            Thread thread1 = new Thread(Hashtag);
            thread1.Start();

            Thread thread2 = new Thread(Star);
            thread2.Start();

            count++;
        }
    }

    static void Hashtag()
    {
        Object _lock = new Object();
        string test;

        lock (_lock)
        {
            for (int i = 0; i < 60; i++)
            {
                Console.Write('#');
                counter++;
            }
            Console.Write(" - " + counter);
            Console.WriteLine();
        }
    }

    static void Star()
    {
        Object _lock = new Object();

        lock (_lock)
        {
            for (int i = 0; i < 60; i++)
            {
                Console.Write('*');
                counter++;
            }
            Console.Write(" - " + counter);
            Console.WriteLine();
        }
    }
}