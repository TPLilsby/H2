using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProject
{
    public interface ILiquid
    {
        void AddLiquid(int milliliters);
        void RemoveLiquid(int milliliters);

        int GetMillilitersOfLiquid();
    }
}
