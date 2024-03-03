using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackr
{
    public interface IExpense
    {
        void AddExpense(double amount, string category);
    }
}
