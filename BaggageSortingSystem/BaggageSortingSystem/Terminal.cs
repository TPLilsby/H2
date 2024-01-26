using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortingSystem
{
    public class Terminal
    {
        public string Name { get; set; }
        public FD Destination { get; set; }
        public Queue<Baggage> Baggages { get; set; }



        public Terminal(string name, FD destination)
        {
            Name = name;
            Destination = destination;
            Baggages =  new Queue<Baggage>();
        }

        public void StartTerminal()
        {
            Thread terminalThread = new Thread(Consume);
            terminalThread.Start();

            Thread flightThread = new Thread(FlyAway);
            flightThread.Start();
        }

        static int count = 0;
        public void FlyAway()
        {

            Random rndflight = new Random();


            Thread.Sleep(rndflight.Next(10000, 20000));

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Flight is on the wings from {Name} to {Destination} with {Baggages.Count} baggages");
            Console.ResetColor();

            Console.WriteLine(count = Baggages.Count + count);
            Baggages.Clear();
        }

        public void Consume()
        {

        }
    }
}
