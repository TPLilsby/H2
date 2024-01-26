using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortingSystem
{
    public class Counter
    {
        public string Name { get; set; }

        public Counter(string name)
        { 
            Name = name;
        }
        public void StartCounter()
        {
            Thread counterThread = new Thread(ProduceBaggage);
            counterThread.Start();
        }

        public void ProduceBaggage()
        {
            for (int i = 0; i < 200; i++)
            {
                string barcode = $"BAG{Name}{i}";
                FD destination = GetRandomDestination();
                Baggage baggage = new Baggage(barcode, destination);

                lock (Sorter.baggageQueue)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Counter {Name} producing baggage with Barcode: {barcode} | and destination: {destination}");
                    Sorter.baggageQueue.Enqueue(baggage);
                    Console.ResetColor();

                    Monitor.PulseAll(Sorter.baggageQueue);

                }
            }
        }

        public static FD GetRandomDestination()
        {
            FD[] destinations = {FD.London, FD.Tokoyo, FD.Oslo, FD.Berlin, FD.Barcelona };
            Random random = new Random();
            return destinations[random.Next(destinations.Length)];
        }
    }
}
