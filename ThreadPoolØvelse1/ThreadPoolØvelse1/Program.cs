
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        //Make a stop watch
        Stopwatch mywatch = new Stopwatch();


        #region ThreadPool
        Console.WriteLine("Thread pool Execution");

        mywatch.Start(); //Start watch

        ProcessWithThreadPoolMethod(); //Method call

        mywatch.Stop(); //Stops watch

        //Print the time for thread pool
        Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedMilliseconds.ToString());

        mywatch.Reset(); //Reset watch
        #endregion

        #region Thread
        Console.WriteLine("Thread Execution");

        mywatch.Start(); //Start watch

        ProcessWithThreadMethod(); //Method call

        mywatch.Stop(); //Stops watch

        //Print the time for thread
        Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedMilliseconds.ToString());
        #endregion
    }

    //Method for thread pool
    static void ProcessWithThreadPoolMethod()
    {
        //Runs process x times
        for (int i = 0; i <= 1000; i++)
        {
            //Call process
            ThreadPool.QueueUserWorkItem(Process);
        }
    }

    //Metthod for thread
    static void ProcessWithThreadMethod()
    {
        //Runs process x times
        for (int i = 0; i <= 1000; i++)
        {
            //Makes a thread & calls process
            Thread obj = new Thread(Process);

            obj.Start(); //Start process
        }
    }

    //Method for Process
    static void Process(object callback)
    {
        for (int i = 0;  i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {

            }
        }
    }
}