using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails_opgave.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public void AddIngredient(string name, string quantity)
        {
            Ingredients.Add(new Ingredient { Name = name, Quantity = quantity});
        }

        public void RemoveIngredient(int ingredientId)
        {
            Ingredients.RemoveAll(i => i.Id == ingredientId);
        }
    }
}
