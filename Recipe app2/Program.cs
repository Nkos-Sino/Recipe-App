using Recipe_app2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeDetails recipeManager = new RecipeDetails();

            int choice;
            do
            {
                { //This is the menu that the user will be indroduced to when entering the application
                    Console.WriteLine("****************************************************************************");
                    Console.WriteLine("Welcome to the Recipe application Please select option by choosing between option 1 and 7");
                    Console.WriteLine("1. Enter recipe details");
                    Console.WriteLine("2. Display recipe list");
                    Console.WriteLine("3. Display recipe");
                    Console.WriteLine("4. Scale recipe");
                    Console.WriteLine("5. Reset quantities");
                    Console.WriteLine("6. Clear all data");
                    Console.WriteLine("7. Exit");
                    Console.WriteLine("****************************************************************************");

                    
                    choice = Convert.ToInt32(Console.ReadLine());

                    //switch cases have been used to to run methods based on the users choice. for exmaple if the user chooses option 1, the enterrecipedetails method will be ran.
                    switch (choice)
                    {
                        case 1:
                            recipeManager.EnterRecipeDetails();
                            break;
                        case 2:
                            recipeManager.DisplayRecipeList();
                            break;
                        case 3:
                            recipeManager.DisplayRecipe();
                            break;
                        case 4:
                            recipeManager.ScaleRecipe();
                            break;
                        case 5:
                            recipeManager.ResetQuantities();
                            break;
                        case 6:
                            recipeManager.ClearAllData();
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;

                    }

                    Console.WriteLine();
                }
            } while (choice != 7); //while loop to keep the applicaiton running until the user enters the number 7
        }
    }
}
