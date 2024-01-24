using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    public class Beer : Bottle
    {
        public Beer ( string name, int id, BT type)
        {
            Name = name;
            Id = id;
            Type = type;
        }
    }
}
