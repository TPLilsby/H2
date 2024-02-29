using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProject
{
    public class EspressoMachine : Machine
    {
        
        public EspressoMachine() : base(new Liquid("Milk"), new Ingredient("Espresso"), 100, 1)
        {

        }

        public override void Brew()
        {
            /* Brew the espresso */
            Console.WriteLine("Brew Espresso");
            Console.WriteLine("Number of cups: " + CupsPerBrew);
        }
    }
}
