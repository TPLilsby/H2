using Cocktails_opgave;
using System.Net.NetworkInformation;
using Cocktails_opgave.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new DrinksContext())
        {
            db.Database.EnsureCreated();

            Console.WriteLine("1. Add Drink\n2. List Drinks\n3. Update Drink\n4. Delete Drink\n5. Search Drinks\n0. Exit");

            while (true)
            {
                Console.WriteLine("Coose an option");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDrink(db);
                        break;
                    case "2":
                        ListDrinks(db);
                        break;
                    case "3":
                        UpdateDrink(db);
                        break;
                    case "4":
                        DeleteDrink(db);
                        break;
                    case "5":
                        SearchDrinks(db);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }

    private static void AddDrink(DrinksContext db)
    {
        Console.Write("Enter drink name: ");
        var name = Console.ReadLine();
        Console.Write("Enter drink category: ");
        var category = Console.ReadLine();
        var drink = new Drink { Name = name, Category = category };

        while (true)
        {
            Console.Write("Add ingredient? (y/n): ");
            if (Console.ReadLine().ToLower() != "y") break;
            Console.Write("Enter ingredient name: ");
            var ingredientName = Console.ReadLine();
            Console.Write("Enter ingredient quantity: ");
            var ingredientQuantity = Console.ReadLine();
            drink.AddIngredient(ingredientName, ingredientQuantity);
        }

        db.Drinks.Add(drink);
        db.SaveChanges();
    }

    private static void ListDrinks(DrinksContext db)
    {
        var drinks = db.Drinks.Include(d => d.Ingredients).ToList();
        foreach (var drink in drinks)
        {
            Console.WriteLine($"Drink: {drink.Name}, Category: {drink.Category}");
            foreach (var ingredient in drink.Ingredients)
            {
                Console.WriteLine($"Ingredient: {ingredient.Name}, Quantity: {ingredient.Quantity}");
            }
        }
    }

    private static void UpdateDrink(DrinksContext db)
    {
        Console.Write("Enter drink ID to update: ");

        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var drink = db.Drinks.Include(d => d.Ingredients).FirstOrDefault(d => d.Id == id);

            if (drink != null)
            {
                Console.Write("Enter new name: ");
                drink.Name = Console.ReadLine();
                Console.Write("Enter new category: ");
                drink.Category = Console.ReadLine();

                while (true)
                {
                    Console.Write("Add ingredient? (y/n): ");
                    if (Console.ReadLine().ToLower() != "y") break;
                    Console.Write("Enter ingredient name: ");
                    var ingredientName = Console.ReadLine();
                    Console.Write("Enter ingredient quantity: ");
                    var ingredientQuantity = Console.ReadLine();
                    drink.AddIngredient(ingredientName, ingredientQuantity);
                }

                db.SaveChanges();
            } 
            else
            {
                Console.WriteLine("Drink not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    private static void DeleteDrink(DrinksContext db)
    {
        Console.Write("Enter drink ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var drink = db.Drinks.Include(d => d.Ingredients).FirstOrDefault(d => d.Id == id);

            if (drink != null)
            {
                db.Drinks.Remove(drink);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Drink not found.");
            }
        } 
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }

    private static void SearchDrinks(DrinksContext db)
    {
        Console.Write("Enter ingredient to search for: ");
        var  ingredientName = Console.ReadLine();
        var drinks = db.Drinks.Include(d => d.Ingredients)
                              .Where(d => d.Ingredients.Any(i => i.Name.Contains(ingredientName)))
                              .ToList();

        foreach (var drink in drinks)
        {
            Console.WriteLine($"Drink: {drink.Name}, Category: {drink.Category}");
            foreach (var ingredient in drink.Ingredients)
            {
                Console.WriteLine($"\tIngredient: {ingredient.Name}, Quantity: {ingredient.Quantity}");
            }
        }

    }
}