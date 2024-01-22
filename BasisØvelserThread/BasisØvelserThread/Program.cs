
 /*
 * C# Program to Create a Simple Thread
 */
 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading;

//Program class
class program
{
    //Mwthod for working Threads
    public void WorkThreadFunction()
    {
        //For loop to write thread 1 & 2
        for (int i = 0; i < 5; i++)
        {
            //Write the name to the console
            Console.WriteLine("[{0}] Thread name: [{1}]", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Name);
        }
    }
}

//Threpog class
class threprog
{
    public static void Main()
    {
        program pg = new program(); //Make program
        Thread thread1 = new Thread(new ThreadStart(pg.WorkThreadFunction)); //Makes thread 2
        thread1.Name = "Test1"; //Set thread 1 name
        thread1.Start(); // Start thread 1
        thread1.Start(2000); //Thread sleeps 2 sec

        Thread thread2 = new Thread(new ThreadStart(pg.WorkThreadFunction)); //Makes thread 2
        thread2.Name = "Test2"; //Set thread 2 name
        thread2.Start(); //Start thread 2


        Console.Read(); //Read user input
    }
}