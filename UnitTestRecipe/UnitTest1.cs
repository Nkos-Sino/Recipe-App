using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Unit_testing_for_recipeApp_2
{
    [TestClass]
    public class RecipeTests
    {
        // Define the Ingredient class
        private class Ingredient
        {
            public string Name { get; set; }
            public int Calories { get; set; }
        }

        // Define the Recipe class
        private class Recipe
        {
            public List<Ingredient> Ingredients { get; set; }

            public Recipe()
            {
                Ingredients = new List<Ingredient>();
            }

            public int CalculateTotalCalories()
            {
                int totalCalories = 0;
                foreach (Ingredient ingredient in Ingredients)
                {
                    totalCalories += ingredient.Calories;
                }
                return totalCalories;
            }
        }

        // Test method for CalculateTotalCalories
        [TestMethod]
        public void CalculateTotalCalories_TotalCaloriesDoesNotExceed300_ReturnsTrue()
        {
            // Arrange
            Recipe recipe = new Recipe(); // Create an instance of the Recipe class

            // Initialize the Ingredients list with known ingredients and their calorie values
            recipe.Ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "Ingredient 1", Calories = 100 },
                new Ingredient { Name = "Ingredient 2", Calories = 150 },
                new Ingredient { Name = "Ingredient 3", Calories = 50 }
            };

            // Act
            int totalCalories = recipe.CalculateTotalCalories(); // Call the method to calculate total calories

            // Assert
            Assert.IsTrue(totalCalories <= 300); // Check if total calories are less than or equal to 300
        }
    }
}
