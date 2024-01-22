
class Program
{
    static void Main(string[] args)
    {
        Thread thread1 = new Thread(Temperature);

        thread1.Start();

        while (thread1.IsAlive)
        {
            return;
        }

        Console.ReadKey();
    }
    static int count = 0;

    static void Temperature()
    {
        while (count < 3)
        {
            Random rnd = new Random();
            int rndTemperatur = rnd.Next(-20, 120);


            Console.WriteLine($"Temnperature: {rndTemperatur}");

            if (rndTemperatur < 0 || rndTemperatur > 120)
            {
                Console.WriteLine("Alarm!!!!");

                count++;
            }

            if (count == 3)
            {
                Console.WriteLine("Programmet stooper");
            }

            Thread.Sleep(2000);
        }

    }
}