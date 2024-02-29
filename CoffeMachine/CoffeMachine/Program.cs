
using System.Reflection.PortableExecutable;

namespace CoffeeMachineProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Machine coffeeMachine = new  CoffeeMachine();
            coffeeMachine.Brew();

            Machine teaMachine = new TeaMachine();
            teaMachine.Brew();

            Machine espressoMachine = new EspressoMachine();
            espressoMachine.Brew();

        }
    }
}