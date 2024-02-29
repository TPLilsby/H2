using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProject
{
    public class TeaMachine : Machine
    {
        public TeaMachine() : base(new Liquid("water"), new Ingredient("Tea"), 100, 10)
        {

        }

        public override void Brew()
        {
            /* Brew the tea */
            Console.WriteLine("Brew Tea");
        }
    }
}
