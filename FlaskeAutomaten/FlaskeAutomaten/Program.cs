
using FlaskeAutomaten;

class Program
{
    static void Main(string[] args)
    {
        Thread producerThread = new Thread(Producer);
        producerThread.Start();

        Thread consumerSplitterThread = new Thread(ConsumerSplitter);
        consumerSplitterThread.Start();

        Thread beerConsumerThread = new Thread(BeerConsumer);
        beerConsumerThread.Start();

        Thread sodaConsumerThread = new Thread(SodaConsumer);
        sodaConsumerThread.Start();


    }

    static Queue<Bottle> bottles = new Queue<Bottle>();
    static void Producer()
    {
        Console.WriteLine("Test");
        int count = 0;

        for (int i = 0; i < 13; i++)
        {
            Console.WriteLine("Test2");
            count++;
            bottles.Enqueue(new Beer("Beer", count, BT.Beer));
        }
    }


    static void ConsumerSplitter()
    {
        while (bottles.Count > 0)
        {
            Bottle b = bottles.Dequeue();

            if (b.Type == BT.Beer)
            {
                beerQueue.Enqueue(b);
                Console.WriteLine(b.Type);
            }
            else if (b.Type == BT.Soda)
            {
                sodaQueue.Enqueue(b);
                Console.WriteLine(b.Type);
            }
        }
    }

    static Queue<Bottle> beerQueue = new Queue<Bottle>();
    static void BeerConsumer()
    {

    }

    static Queue<Bottle> sodaQueue = new Queue<Bottle>();
    static void SodaConsumer()
    {

    }
}