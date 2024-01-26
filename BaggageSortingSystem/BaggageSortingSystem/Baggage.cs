using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortingSystem
{
    public class Baggage
    {
        public string Barcode { get; set; }
        public FD Destination { get; set; }

        public Baggage(string barcode, FD destination)
        {
            Barcode = barcode;
            Destination = destination;
        }
    }
}

