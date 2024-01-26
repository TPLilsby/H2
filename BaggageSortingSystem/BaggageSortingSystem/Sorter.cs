using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BaggageSortingSystem
{
    public class Sorter
    {
        // Shared queue for incoming baggages
        public static Queue<Baggage> baggageQueue = new Queue<Baggage>();

        // List of terminals connected to the sorter
        public List<Terminal> Terminals { get; set; }

        // Constructor to initialize the sorter with a list of terminals
        public Sorter(List<Terminal> terminals)
        {
            Terminals = terminals;
        }

        // Method to split and distribute baggages to their respective terminals
        public void Splitter()
        {
            while (true)
            {
                Baggage baggage;

                lock (baggageQueue)
                {
                    // Wait until there is at least one baggage in the queue
                    while (baggageQueue.Count == 0)
                    {
                        Monitor.Wait(baggageQueue);
                    }

                    // Dequeue a baggage for processing
                    baggage = baggageQueue.Dequeue();

                    // Distribute the baggage to the appropriate terminal
                    foreach (Terminal terminal in Terminals)
                    {
                        if (baggage.Destination == terminal.Destination)
                        {
                            terminal.Baggages.Enqueue(baggage);
                        }
                    }

                    // Display information about the sorted baggage
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Baggage with Barcode {baggage.Barcode} sorted by {Thread.CurrentThread.Name} for Destination {baggage.Destination}");
                    Console.ResetColor();
                }
            }
        }

        // Method to start the sorter thread
        public void StartSorter()
        {
            // Start a thread for the sorting process
            Thread sorterThread = new Thread(Splitter);
            sorterThread.Start();
        }
    }
}
