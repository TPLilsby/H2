
class Program
{
    static void Main()
    {
        Console.WriteLine("[{0}]Main called", Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("[{0}] Processor/core count = {1}",
           Thread.CurrentThread.ManagedThreadId,
           Environment.ProcessorCount);


        Thread t = new Thread(SayHallo);
        t.Name = "Hallo World";
        t.Priority = ThreadPriority.Highest;

        t.Start();

        t.Join();

        Console.WriteLine("[{0}] Main done", Thread.CurrentThread.ManagedThreadId);
        Console.ReadKey();
    }


    static void SayHallo()
    {
        Console.WriteLine("[{0}] Hello world!", Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("[{0}]Main called", Thread.CurrentThread.Name);
    }


}