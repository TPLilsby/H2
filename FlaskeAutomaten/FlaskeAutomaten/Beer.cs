using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    public class Beer : Bottle
    {
        public Beer ( string name, int id, BT type)
        {
            Name = name;
            Id = id;
            Type = type;
        }


        public static Queue<Bottle> beerQueue = new Queue<Bottle>();
        public static void BeerConsumer()
        {
            int count = 0;

            while (true)
            {
                lock (beerQueue)
                {
                    while (beerQueue.Count == 0)
                    {
                        Monitor.Wait(beerQueue);
                    }

                    Bottle b = beerQueue.Dequeue();
                    count++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Thread.CurrentThread.Name} : Has consumed a {b.Name}: {b.Id}");

                    Monitor.PulseAll(beerQueue);
                }
            }
        }
    }
}
