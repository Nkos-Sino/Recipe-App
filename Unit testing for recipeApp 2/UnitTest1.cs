using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_testing_for_recipeApp_2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateTotalCalories_TotalCaloriesDoesNotExceed300_ReturnsTrue()
        {
            {
                // Arrange
                Recipe recipe = new Recipe();
                recipe.Ingredients = new List<Ingredient>
    {
        new Ingredient { Name = "Ingredient 1", Calories = 100 },
        new Ingredient { Name = "Ingredient 2", Calories = 150 },
        new Ingredient { Name = "Ingredient 3", Calories = 50 }
    };

                // Act
                int totalCalories = recipe.CalculateTotalCalories();

                // Assert
                Assert.LessOrEqual(totalCalories, 300);
            }

        }
    }
}
