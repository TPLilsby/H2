using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackr
{
    public interface IApplication
    {
        void PromptForExpenseDetails();

        void HandleUserInput(string choice);
    }
}
