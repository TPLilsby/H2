using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackr
{
    public class Expense
    {
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public string Format()
        {
            return $"Date: {Date.ToShortDateString()}, Category: {Category}, Amount: {Amount:C}";
        }
    }
}
