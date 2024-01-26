using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortingSystem
{
    public class Baggage
    {
        // Property to store the barcode of the baggage
        public string Barcode { get; set; }

        // Property to store the destination of the baggage
        public FD Destination { get; set; }

        // Constructor to initialize the baggage with a barcode and destination
        public Baggage(string barcode, FD destination)
        {
            Barcode = barcode;
            Destination = destination;
        }
    }
}
