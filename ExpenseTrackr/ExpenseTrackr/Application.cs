using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackr
{
    public class Application : IApplication
    {
        ExpenseManager expenseManager = new ExpenseManager();

        public void PromptForExpenseDetails()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your choice:");

                string choice = Console.ReadLine();

                HandleUserInput(choice);
            }

        }

        public void HandleUserInput(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter expense amount:");
                    double amount = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter expensecategory");
                    string category = Console.ReadLine();

                    expenseManager.AddExpense(amount, category);
                    break;

                case "2":
                    Console.WriteLine("1. View all expenses");
                    Console.WriteLine("2. Sort expenses by date");
                    Console.WriteLine("3. Sort expenses by category");

                    string viewChoice = Console.ReadLine();

                    switch (viewChoice)
                    {
                        case "1":
                            expenseManager.DisplayAllExpenses();
                            break;

                        case "2":
                            expenseManager.DisplayExpensesSortedByDate();
                            break;

                        case "3":
                            expenseManager.DisplayExpensesSortedByCategory();
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;

            }
        }
    }
}
