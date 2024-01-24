
class Program
{
    static Queue<int> products = new Queue<int>(9);
    static void Main(string[] args)
    {
        Thread produceThread = new Thread(Producer);
        produceThread.Name = "Thread 1";
        produceThread.Start();

        Thread consumerThread = new Thread(Consumer);
        consumerThread.Name = "Thread 2";
        consumerThread.Start();
    }

    static void Producer()
    {
        int count = 0;

        while (true)
        {
            if (products.Count < 3)
            {
                count++;
                products.Enqueue(count);
                Console.WriteLine("\nProduced" + count);
            }
            else
            {
                Console.WriteLine("Kan ikke producere flere.");
            }

            Thread.Sleep(6000);
        }
    }

    static void Consumer()
    {
        while (true)
        {

            if (products.Count > 0)
            {

                products.Dequeue();
                Console.WriteLine("Consumed");
            }
        }
    }
}