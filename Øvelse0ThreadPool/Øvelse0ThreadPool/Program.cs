/*
 * C# Program to Create Thread Pools
*/

using System;
using System.Threading;

//ThreadPoolDemo class
class ThreadPoolDemo
{
    //Method for task 1
    public void task1(object obj)
    {
        //For loop for task 1 execution
        for (int i = 0; i <= 2; i++)
        {
            //Prints to the Console
            Console.WriteLine("Task 1 is being executed");
        }
    }

    //Method for task 2
    public void task2(object obj)
    {
        //For loop for task 2 execution
        for (int i = 0; i <= 2; i++)
        {
            //Prints to the console
            Console.WriteLine("Task 2 is being executed");
        }
    }
 
    //Main method
    static void Main()
    {
        //Make the class a varible name
        ThreadPoolDemo tpd = new ThreadPoolDemo();

        //Runs through both thread pools 2 times each
        for (int i = 0; i < 2; i++)
        {
            ThreadPool.QueueUserWorkItem(tpd.task1);
            ThreadPool.QueueUserWorkItem(tpd.task2);
        }

        //Read the input in the console
        Console.Read();
    }

}