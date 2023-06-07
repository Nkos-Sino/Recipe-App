using RecipeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_app2
{
    class Ingredientinfo //This class holds the ingredient information. it also includes getters and setters to get and sett the ingredient information.
    {
        public string Name { get; }
        public double Quantity { get; set; }
        public string Unit { get; }
        public int Calories { get; }
        public string FoodGroup { get; }

        public Ingredientinfo(string name, double quantity, string unit, int calories, string foodGroup) // this method gets and set the ingredient information
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        public void ResetQuantity() // this reset quantity method resets the quantity of the ingredient entered.
        {
            Quantity = 0;
        }
    }
    class Recipe // the recipe class includes all the information entered by the user about recipe
    {
        public string Name { get; set; }
        public List<Ingredientinfo> Ingredients { get; }
        public List<string> Steps { get; }

        public Recipe()
        {
            Ingredients = new List<Ingredientinfo>();
            Steps = new List<string>();
        }

        public void AddIngredientintoRecipe(Ingredientinfo ingredient) //method to add ingredients into the recipe 
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(string step) //method to add steps 
        {
            Steps.Add(step);
        }

        public int CalculateTotalCalories() //method to calculate the total calories entered by the user.
        {
            int totalCalories = 0;

            foreach (Ingredientinfo ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }

            return totalCalories;
        }

        public void ScaleIngredients(double factor) //method to scale ingredients according to the factor entered below
        {
            foreach (Ingredientinfo ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetIngredients()
        {
            foreach (Ingredientinfo ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }
    }
    internal class RecipeDetails
    {
        
            private List<Recipe> recipes;
            private Recipe selectedRecipe;

            public RecipeDetails()
            {
                recipes = new List<Recipe>();
            }
            //Method to enter recipes and the steps 
            public void EnterRecipeDetails()
            {
                Recipe recipe = new Recipe();


                Console.Write("Enter the recipe name: ");
                recipe.Name = Console.ReadLine();

                Console.Write("Enter the number of ingredients: ");
            int ingredientCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < ingredientCount; i++)
                {
                    Console.WriteLine($"Enter details for ingredient number #{i + 1}:");
                    Console.Write("Ingredient Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Ingredient Quantity: ");
                    double Quantity = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Ingredient Unit of measurement: ");
                    string unit = Console.ReadLine();
                    Console.Write("Ingredient Calories: ");
                int calories = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Ingreditent Food group: ");
                    string foodGroup = Console.ReadLine();

                    Ingredientinfo ingredient = new Ingredientinfo(name, Quantity, unit, calories, foodGroup);
                    recipe.AddIngredientintoRecipe(ingredient);
                }

                Console.Write("Enter the number of steps for the recipe: ");
                int stepCount = Convert.ToInt32(Console.ReadLine());
                
                for (int i = 0; i < stepCount; i++)
                {
                    Console.Write($"Enter step number #{i + 1}: ");
                    string step = Console.ReadLine();
                    recipe.AddStep(step);
                }

                recipes.Add(recipe);

                Console.WriteLine("Recipe have been successfully captured.");
            }
            //displaying the recipe entered
            public void DisplayRecipeList()
            {
                if (recipes.Count == 0)
                {
                    Console.WriteLine("No recipes found.");
                    return;
                }

                Console.WriteLine("Recipe List:");

                List<Recipe> sortedRecipes = recipes.OrderBy(r => r.Name).ToList();

                for (int i = 0; i < sortedRecipes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {sortedRecipes[i].Name}");
                }

                Console.Write("Enter the number of the recipe you wish to display: ");
                int recipeNumber = Convert.ToInt32(Console.ReadLine());
                while (!int.TryParse(Console.ReadLine(), out recipeNumber) || recipeNumber < 1 || recipeNumber > sortedRecipes.Count)
                {
                    Console.WriteLine("Invalid input. Please enter a valid recipe number.");
                    Console.Write("Enter the number of the recipe to display: ");
                }

                selectedRecipe = sortedRecipes[recipeNumber - 1];
                Console.WriteLine($"Recipe '{selectedRecipe.Name}' selected.");
            }

            public void DisplayRecipe()
            {
                if (selectedRecipe == null)
                {
                    Console.WriteLine("No recipe selected.");
                    return;
                }

                Console.WriteLine($"Recipe '{selectedRecipe.Name}':");

                Console.WriteLine("Ingredients:");
                for (int i = 0; i < selectedRecipe.Ingredients.Count; i++)
                {
                    Ingredientinfo ingredient = selectedRecipe.Ingredients[i];
                    Console.WriteLine($"{i + 1}. {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
                }

                Console.WriteLine("Steps:");
                for (int i = 0; i < selectedRecipe.Steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {selectedRecipe.Steps[i]}");
                }

                Console.WriteLine($"Total calories: {selectedRecipe.CalculateTotalCalories()}");

                if (selectedRecipe.CalculateTotalCalories() > 300)
                {
                    Console.WriteLine("Total calories have exceed 300!");
                }
            }
            //Method to scale the recipe 
            public void ScaleRecipe()
            {
                if (selectedRecipe == null)
                {
                    Console.WriteLine("No recipe selected.");
                    return;
                }

                Console.Write("Enter the scaling factor (0.5, 2, or 3): ");
                double factor;
                while (!double.TryParse(Console.ReadLine(), out factor) || (factor != 0.5 && factor != 2 && factor != 3))
                { //use the numbers (1) for 0.5 scaling factor,(2) for 2 scaling factor,or (3) for 3 scaling factor 
                    Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3 for the scaling factor.");
                    Console.Write("Enter the scaling factor (0.5, 2, or 3): ");
                }

                selectedRecipe.ScaleIngredients(factor);

                Console.WriteLine("Recipe has scaled successfully.");
            }
            //Method to rest the recipe 
            public void ResetQuantities()
            {
                if (selectedRecipe == null)
                {
                    Console.WriteLine("No recipe selected.");
                    return;
                }

                selectedRecipe.ResetIngredients();

                Console.WriteLine("Quantities reset to original values.");
            }
            //Method to clear all the data in the recipe  
            public void ClearAllData()
            {
                recipes.Clear();
                selectedRecipe = null;

                Console.WriteLine("All data cleared.");
            }
        }
    }

