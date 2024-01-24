
class Program
{
    static int count = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Thread thread1 = new Thread(AddOne);
            thread1.Start();

            Thread.Sleep(1000);

            Thread thread2 = new Thread(MinusOne);
            thread2.Start();

            Thread.Sleep(2000);

            thread1.Join();
        }
    } 

    static void AddOne()
    {
        count = count + 2;

        Console.WriteLine(count);
    }

    static void MinusOne()
    {
        count--;



        Console.WriteLine(count);
    }
}