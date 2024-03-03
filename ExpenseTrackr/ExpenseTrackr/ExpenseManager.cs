using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackr
{
    public class ExpenseManager : IDisplay, IExpense
    {
        private List<Expense> expenses = new List<Expense>();

        public void AddExpense(double amount, string category)
        {
            Expense expense = new Expense
            {
                Amount = amount,
                Category = category,
                Date = DateTime.Now,
            };

            expenses.Add(expense);

            Console.Clear();
            Console.WriteLine("Expense added successfully.");
        }

        public void DisplayAllExpenses()
        {
            Console.Clear();
            Console.WriteLine("Expenses");

            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses to display");
                return;
            }

            foreach (Expense expense in expenses)
            {
                Console.WriteLine(expense.Format());
            }
        }

        public void DisplayExpensesSortedByDate()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses to display");
                return;
            }

            var sortedExpenses = expenses.OrderBy(expense => expense.Date);

            Console.WriteLine("Expenses sorted by date:");

            foreach (var expense in sortedExpenses)
            {
                Console.WriteLine(expense.Format());
            }

        }

        public void DisplayExpensesSortedByCategory()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses to display");
                return;
            }

            var sortedExpenses = expenses.OrderBy(expense => expense.Category);

            Console.WriteLine("Expenses sorted by category:");
            
            foreach (var expense in sortedExpenses)
            {
                Console.WriteLine(expense.Format());
            }
        }
    }
}
