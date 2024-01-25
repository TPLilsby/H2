using FlaskeAutomaten;
using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Thread for producer
        Thread producerThread = new Thread(Producer);
        producerThread.Name = "Producer"; // Thread name
        producerThread.Start(); // Thread start

        // Thread for the splitter Consumer
        Thread consumerSplitterThread = new Thread(ConsumerSplitter);
        consumerSplitterThread.Name = "-splitter Consumer"; // Thread name
        consumerSplitterThread.Start(); // Thread start

        // Thread for the beer Consumer
        Thread beerConsumerThread = new Thread(Beer.BeerConsumer);
        beerConsumerThread.Name = "Beer Consumer"; // Thread name
        beerConsumerThread.Start(); // Thread start

        // Thread for the soda Consumer
        Thread sodaConsumerThread = new Thread(Soda.SodaConsumer);
        sodaConsumerThread.Name = "Soda Consumer"; // Thread name
        sodaConsumerThread.Start(); // Thread start

        Console.ReadLine();
    }

    // Random number generator for queue capacity
    static Random rndQueueCapacity = new Random();

    // Generate a random capacity for the queue
    static int capacity = rndQueueCapacity.Next(24, 34);

    // Queue with all the bottles
    public static Queue<Bottle> bottles = new Queue<Bottle>(capacity);

    // Producer method
    static void Producer()
    {
        // Random number generator for bottle choice
        Random rndBottleChoice = new Random();

        // Variable for counting the bottles id
        int idCount = 0;

        // Loop for producing bottles up to the specified capacity
        for (int i = 1; i <= capacity; i++)
        {
            // Lock the bottles queue to ensure thread safety
            lock (bottles)
            {
                // Generate a random number to decide which type of bottle to produce (Beer or Soda)
                int whatToProduce = rndBottleChoice.Next(1, 3);

                if (whatToProduce == 1)
                {
                    // Produce Beer and enqueue it to the shared bottles queue
                    idCount++;
                    bottles.Enqueue(new Beer("Beer", idCount, BT.Beer));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Beer created " + idCount);
                    Console.ResetColor();
                }
                else if (whatToProduce == 2)
                {
                    // Produce Soda and enqueue it to the shared bottles queue
                    idCount++;
                    bottles.Enqueue(new Soda("Soda", idCount, BT.Soda));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Soda created: " + idCount);
                    Console.ResetColor();
                }

                // Simulate some delay between production of bottles
                Thread.Sleep(2000);

                // Notify waiting threads that the queue has been modified
                Monitor.PulseAll(bottles);
            }
        }

        // Display a message indicating the total number of bottles produced
        Console.WriteLine("\nBottles were produced!!! " + idCount);
    }


    // Consumer splitter method responsible for distributing bottles from the main queue to specialized queues
    static void ConsumerSplitter()
    {
        // Infinite loop to continuously process bottles
        while (true)
        {
            // Lock the main bottles queue to ensure thread safety
            lock (bottles)
            {
                // Wait until there is at least one bottle in the main queue
                while (bottles.Count == 0)
                {
                    Monitor.Wait(bottles);
                }

                // Dequeue a bottle from the main queue
                Bottle b = bottles.Dequeue();

                try
                {
                    // Check the type of the bottle and enqueue it into it's own queue
                    if (b is Beer)
                    {
                        // Lock the Beer queue for thread safety
                        lock (Beer.beerQueue)
                        {
                            // Enqueue the Beer bottle into the specialized Beer queue
                            Beer.beerQueue.Enqueue(b);

                            // Notify waiting threads that the Beer queue has been modified
                            Monitor.PulseAll(Beer.beerQueue);
                        }
                    }
                    else if (b is Soda)
                    {
                        // Lock the Soda queue for thread safety
                        lock (Soda.sodaQueue)
                        {
                            // Enqueue the Soda bottle into the specialized Soda queue
                            Soda.sodaQueue.Enqueue(b);

                            // Notify waiting threads that the Soda queue has been modified
                            Monitor.PulseAll(Soda.sodaQueue);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during the enqueuing process
                    Console.WriteLine(ex);
                }

                // Notify waiting threads that the main queue has been modified
                Monitor.PulseAll(bottles);
            }
        }
    }}
