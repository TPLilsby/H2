using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningPhilophers
{
    public class Philopher
    {
        public string Name { get; set; }
        public Fork RightFork { get; set; }
        public Fork LeftFork { get; set; }
        public FS State { get; set; }

        public Philopher (string name, Fork rightFork, Fork leftFork)
        {
            this.Name = name;
            this.RightFork = rightFork;
            this.LeftFork = leftFork;
            this.State = FS.Think;
        }

        public void Philo()
        {
            Random rnd = new Random();

            int count = 0;

            while (count != 100)
            {
                switch (State)
                {
                    case FS.Think:
                        Console.WriteLine("\n" + Thread.CurrentThread.Name + " is Thinking");
                        Thread.Sleep(rnd.Next(500, 4000));
                        State = FS.Wait;
                        break;

                    case FS.Wait:
                        Console.WriteLine(Thread.CurrentThread.Name + " Try's to get forks - " + RightFork.Name + " and " + LeftFork.Name);
                        GetFork(RightFork, LeftFork);
                        break;

                    case FS.Eat:
                        Console.WriteLine(Thread.CurrentThread.Name + " spiser");
                        Thread.Sleep(rnd.Next(1000, 5000));
                        State = FS.Think;
                        break;
                }
                count++;
            }
        }

        
        void GetFork(Fork right, Fork left)
        {
            if (Monitor.TryEnter(right))
            {
                    if (Monitor.TryEnter(left))
                    {
                        State = FS.Eat;
                        Monitor.Exit(right);
                        Monitor.Exit(left);
                        return;
                    }
                    State = FS.Wait;
            }

            State = FS.Think;

        }


    }
}
