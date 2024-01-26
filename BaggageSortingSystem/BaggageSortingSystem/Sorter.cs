using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortingSystem
{
    public class Sorter


    {
        public static Queue<Baggage> baggageQueue = new Queue<Baggage>();
        public List<Terminal> Terminals {  get; set; }

        public Sorter(List<Terminal> terminals)
        {
            Terminals = terminals;
        }
        public void Splitter()
        {
            while (true)
            {
                Baggage baggage;

                lock (baggageQueue)
                {
                    while (baggageQueue.Count == 0)
                    {
                        Monitor.Wait(baggageQueue);
                    }
                        baggage = baggageQueue.Dequeue();

                    foreach (Terminal terminal in Terminals)
                    {

                        if (baggage.Destination == terminal.Destination)
                        {
                            terminal.Baggages.Enqueue(baggage);
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Baggage with Barcode {baggage.Barcode} sorted by {Thread.CurrentThread.Name} for Destination {baggage.Destination}");
                    Console.ResetColor();
                }
            }
        }

        public void StartSorter ()
        {
            Thread sorterThread = new Thread(Splitter);
            sorterThread.Start();
        }
    }
}
