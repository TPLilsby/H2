using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BaggageSortingSystem
{
    public class Counter
    {
        // Property to store the name of the counter
        public string Name { get; set; }

        // Constructor to initialize the counter with a name
        public Counter(string name)
        {
            Name = name;
        }

        // Method to start the counter thread for producing baggages
        public void StartCounter()
        {
            // Start a thread for baggage production
            Thread counterThread = new Thread(ProduceBaggage);
            counterThread.Start();
        }

        // Method representing the baggage production process
        public void ProduceBaggage()
        {
            for (int i = 0; i < 200; i++)
            {
                // Generate a unique barcode for each baggage
                string barcode = $"BAG{Name}{i}";

                // Get a random destination for the baggage
                FD destination = GetRandomDestination();

                // Create a new baggage with the generated barcode and destination
                Baggage baggage = new Baggage(barcode, destination);

                // Use lock to ensure thread-safe access to shared resources
                lock (Sorter.baggageQueue)
                {
                    // Display information about the produced baggage
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Counter {Name} producing baggage with Barcode: {barcode} | and destination: {destination}");

                    // Enqueue the baggage to the shared baggage queue
                    Sorter.baggageQueue.Enqueue(baggage);

                    // Reset console color
                    Console.ResetColor();

                    // Notify other threads waiting on the shared queue
                    Monitor.PulseAll(Sorter.baggageQueue);
                }
            }
        }

        // Method to get a random destination from the FD enum
        public static FD GetRandomDestination()
        {
            FD[] destinations = { FD.London, FD.Tokoyo, FD.Oslo, FD.Berlin, FD.Barcelona };
            Random random = new Random();
            return destinations[random.Next(destinations.Length)];
        }
    }
}
