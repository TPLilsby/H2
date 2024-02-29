using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProject
{
    public class Ingredient : IIngredient
    {

        public string Name { get; private set; }
        public int GramsOfIngredient { get; private set; }

        public Ingredient(string name)
        {
            Name = name;
        }

        public void AddIngredient(int grams)
        {
            GramsOfIngredient += grams;

        }

        public void RemoveIngredient(int grams)
        {
            GramsOfIngredient -= grams;
        }

        public int GetGramsOfIngredient()
        {
            return GramsOfIngredient;
        }
    }
}
