using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    // Soda class inherits from Bottle
    public class Soda : Bottle
    {
        // Constructor for Soda class
        public Soda(string name, int id, BT type)
        {
            // Initialize properties inherited from Bottle class
            Name = name;
            Id = id;
            Type = type;
        }

        // Static queue to hold instances of the Bottle class (soda bottles)
        public static Queue<Bottle> sodaQueue = new Queue<Bottle>();

        // Method representing the soda consumer
        public static void SodaConsumer()
        {
            // Variable to keep track of consumed soda count
            int count = 0;

            // Infinite loop to keep the consumer running
            while (true)
            {
                // Lock the sodaQueue to ensure thread safety
                lock (sodaQueue)
                {
                    // Check if the queue is empty
                    while (sodaQueue.Count == 0)
                    {
                        // If empty, release the lock and wait for a notification
                        Monitor.Wait(sodaQueue);
                    }

                    // Dequeue a soda bottle from the queue
                    Bottle s = sodaQueue.Dequeue();
                    count++;

                    // Display a message indicating that a soda bottle has been consumed
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Thread.CurrentThread.Name} : Has consumed a {s.Name}: {s.Id}");

                    // Notify other waiting threads that the queue has been modified
                    Monitor.PulseAll(sodaQueue);
                }
            }
        }
    }
}
