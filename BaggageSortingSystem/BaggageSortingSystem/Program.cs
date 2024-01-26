using BaggageSortingSystem;
using System.Diagnostics.Metrics;
using System.Globalization;

public class Program
{
    // Main method
    static void Main(string[] args)
    {
        // Create counters
        List<Counter> counters = new List<Counter>();

        // Initialize and add counters to the list
        Counter counter1 = new Counter("Counter 1");
        counters.Add(counter1);

        Counter counter2 = new Counter("Counter 2");
        counters.Add(counter2);

        Counter counter3 = new Counter("Counter 3");
        counters.Add(counter3);

        Counter counter4 = new Counter("Counter 4");
        counters.Add(counter4);

        Counter counter5 = new Counter("Counter 5");
        counters.Add(counter5);

        // Create terminals
        List<Terminal> terminals = new List<Terminal>();

        // Initialize and add terminals to the list
        Terminal terminal1 = new Terminal("Terminal 1", FD.London);
        terminals.Add(terminal1);

        Terminal terminal2 = new Terminal("Terminal 2", FD.Tokoyo);
        terminals.Add(terminal2);

        Terminal terminal3 = new Terminal("Terminal 3", FD.Oslo);
        terminals.Add(terminal3);

        Terminal terminal4 = new Terminal("Terminal 4", FD.Berlin);
        terminals.Add(terminal4);

        Terminal terminal5 = new Terminal("Terminal 5", FD.Barcelona);
        terminals.Add(terminal5);

        // Create a sorter with the list of terminals
        Sorter sorter = new Sorter(terminals);

        // Start counters to simulate baggage check-in
        foreach (Counter counter in counters)
        {
            counter.StartCounter();
        }

        // Begin the sorting process using the sorter
        sorter.StartSorter();

        // Start terminals to simulate baggage pickup
        foreach (Terminal terminal in terminals)
        {
            terminal.StartTerminal();
        }
    }
}
