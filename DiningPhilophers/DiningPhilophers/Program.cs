
using DiningPhilophers;

class Programn
{
    static void Main(string[] args)
    {
        Fork f1 = new Fork("Fork 1");
        Fork f2 = new Fork("Fork 2");
        Fork f3 = new Fork("Fork 3");

        Philopher philo1 = new Philopher("Benjamin", f3, f1);
        Philopher philo2 = new Philopher("Tobias", f1, f2);
        Philopher philo3 = new Philopher("Rasmus", f2, f3);

        Thread thread1 = new Thread(philo1.Philo);
        thread1.Name = philo1.Name;
        thread1.Start();

        Thread thread2 = new Thread(philo2.Philo);
        thread2.Name = philo2.Name;
        thread2.Start();


        Thread thread3 = new Thread(philo3.Philo);
        thread3.Name = philo3.Name;
        thread3.Start();

    }
}