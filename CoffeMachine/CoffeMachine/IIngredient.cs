using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProject
{
    public interface IIngredient
    {
        void AddIngredient(int grams);

        void RemoveIngredient(int grams);

        int GetGramsOfIngredient();
    }
}
