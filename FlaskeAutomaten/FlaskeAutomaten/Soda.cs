using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaskeAutomaten
{
    public class Soda : Bottle
    {
        public Soda (string name, int id, BT type)
        {
            Name = name;
            Id = id;
            Type = type;
        }
    }
}
