using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BaggageSortingSystem
{
    public class Terminal
    {
        // Properties of the Terminal class
        public string Name { get; set; }
        public FD Destination { get; set; }
        public Queue<Baggage> Baggages { get; set; }

        // Constructor to initialize the Terminal with a name and destination
        public Terminal(string name, FD destination)
        {
            Name = name;
            Destination = destination;
            Baggages = new Queue<Baggage>();
        }

        // Method to start the terminal operations
        public void StartTerminal()
        {
            // Start a thread for baggage consumption
            Thread terminalThread = new Thread(Consume);
            terminalThread.Start();

            // Start a thread for flight departure
            Thread flightThread = new Thread(FlyAway);
            flightThread.Start();
        }

        // Static count to keep track of total baggages flown away
        static int count = 0;

        // Method representing the flight departure process
        public void FlyAway()
        {
            // Simulate flight delay with a random sleep duration
            Random rndflight = new Random();
            Thread.Sleep(rndflight.Next(10000, 20000));

            // Display flight information and the number of baggages
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nFlight is on the wings from {Name} to {Destination} with {Baggages.Count} baggages");
            Console.ResetColor();

            // Update and display the total count of baggages flown away
            Console.WriteLine($"Baggage flown away: {count = Baggages.Count + count}");

            // Clear the baggages queue after flight departure
            Baggages.Clear();
        }

        // Method representing the baggage consumption process
        public void Consume()
        {

        }
    }
}
