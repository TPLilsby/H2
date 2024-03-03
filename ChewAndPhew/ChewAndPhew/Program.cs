
namespace ChewAndPhew
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispenser dispenser = Dispenser.Instance;
            dispenser.Dispense();

            Console.WriteLine(dispenser.GetBubbleGum().Flavor);

            Console.WriteLine(dispenser.MaxCapacity);

            BubbleGum bubble = dispenser.GetBubbleGum();

            if (bubble != null)
            {
                Console.WriteLine($"Retrieved bubblegum with flavor: {bubble.Flavor}");

                // Ask user if they want to remove the bubblegum
                Console.WriteLine("Do you want to remove this bubblegum from the dispenser? (yes/no)");
                string input = Console.ReadLine();

                if (input.ToLower() == "yes")
                {
                    // Remove the bubblegum from the dispenser
                    dispenser.RemoveBubbleGum(bubble);
                    Console.WriteLine("Bubblegum removed from the dispenser.");
                }
                else
                {
                    Console.WriteLine("Bubblegum not removed from the dispenser.");
                }
            }
            else
            {

            }
                Console.WriteLine(dispenser.MaxCapacity);
        }
    }
}