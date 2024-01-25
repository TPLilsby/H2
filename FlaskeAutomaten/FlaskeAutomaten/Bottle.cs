using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    // Class representing a basic bottle
    public class Bottle
    {
        // Property representing the name of the bottle
        public string Name { get; set; }

        // Property representing the unique identifier of the bottle
        public int Id { get; set; }

        // Property representing the type of the bottle
        public BT Type { get; set; }
    }
}
