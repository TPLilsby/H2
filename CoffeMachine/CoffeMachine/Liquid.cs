using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProject
{
    public class Liquid : ILiquid
    {
        public string Name { get; private set; }
        public int MillilitersOfLiquid { get; private set; }

        public Liquid(string name)
        {
            Name = name;
        }

        public void AddLiquid(int milliliters)
        {
            MillilitersOfLiquid += milliliters;
        }

        public void RemoveLiquid(int milliliters)
        {
            MillilitersOfLiquid -= milliliters;
        }

        public int GetMillilitersOfLiquid()
        {
            return MillilitersOfLiquid;
        }
    }
}
