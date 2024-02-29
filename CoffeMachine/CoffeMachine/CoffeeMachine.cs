using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProject
{
    public class CoffeeMachine : Machine
    {
        public CoffeeMachine() : base(new Liquid("water"), new Ingredient("Coffee"), 100, 2)
        {

        }

        public override void Brew()
        {
            /* Brew the coffee */
            Console.WriteLine("Brew Coffee");
        }
    }
}
