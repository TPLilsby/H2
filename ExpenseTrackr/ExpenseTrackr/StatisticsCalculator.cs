using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackr
{
    public class StatisticsCalculator : IStatisticsCalculator
    {
        public double CalculateTotalExpenses(List<Expense> expenses)
        {
            double total = 0;

            foreach (var expense in expenses)
            {
                total += expense.Amount;
            }

            return total;
        }
    }
}
