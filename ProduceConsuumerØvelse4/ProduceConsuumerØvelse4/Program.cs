
class Program
{
    static Queue<int> products = new Queue<int>(9);
    Object _lock = new Object();

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
        while (true)
        {
            lock (products)
            {
                for (int i = 0; i < 10; i++)
                {
                    products.Enqueue(i);
                    Thread.Sleep(500);
                    Console.WriteLine("Opretter: " + i);
                }
                    Monitor.PulseAll(products);
            }
            Console.WriteLine("333333333333333333333333: " + products.Count);
            Thread.Sleep(2000);
        }
    }

    static void Consumer()
    {
        while (true)
        {
            lock (products)
            {
                while (products.Count  <= 3)
                {

                    Console.WriteLine("Consumer venter!");
                    Monitor.Wait(products);
                }


                Console.WriteLine("qConsumer produkt: " + products.Dequeue());


            }
            Console.WriteLine(products.Count);
        }
    }
}