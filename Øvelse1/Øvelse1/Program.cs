
using System.Threading;

class Program
{
    //Øvelse 1 & 2 Thread
    static void Main(string[] args)
    {
        Thread thread1 = new Thread(PrintThread1);
        thread1.Start();

        Thread thread2 = new Thread(PrintThread2);
        thread2.Start();


    }

    static void PrintThread1()
    {
        for (int i = 0; i <= 4; i++)
        {
            Console.WriteLine("C#-trådning er nemt!");

            Thread.Sleep(2000);
        }

    }

    static void PrintThread2()
    {
        for (int i = 0;i <= 4; i++)
        {
            Console.WriteLine("Også med flere tråde …");

            Thread.Sleep(2000);
        }
    }
}