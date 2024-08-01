using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace RecipeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
      
        [TestMethod]
        public void CalculateTotalCalories_ReturnsCorrectTotal()
        {
            // Arrange
            Recipe recipe = new Recipe();
            // Mocking the behavior of adding ingredients to the recipe
            recipe.AddIngredientintoRecipe(new Ingredientinfo("Ingredient 1", 100, "grams", 50, "Group 1"));
            recipe.AddIngredientintoRecipe(new Ingredientinfo("Ingredient 2", 150, "grams", 70, "Group 2"));
            recipe.AddIngredientintoRecipe(new Ingredientinfo("Ingredient 3", 200, "grams", 80, "Group 1"));

            // Act
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(200, totalCalories); // Total calories should be 200 (50 + 70 + 80)
        }
    }

    internal class Ingredientinfo
    {
        private string v1;
        private int v2;
        private string v3;
        private int v4;
        private string v5;

        public Ingredientinfo(string v1, int v2, string v3, int v4, string v5)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
        }
    }
}

