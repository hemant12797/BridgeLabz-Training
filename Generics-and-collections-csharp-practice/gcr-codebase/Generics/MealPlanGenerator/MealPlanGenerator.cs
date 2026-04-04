using System;

namespace MealPlanGenerator
{
    public class MealPlanGeneratorService
    {
        public void GenerateMealPlan(string category)
        {
            switch (category)
            {
                case "Vegetarian":
                    GenerateMealPlan<VegetarianMeal>();
                    break;
                case "Vegan":
                    GenerateMealPlan<VeganMeal>();
                    break;
                case "Keto":
                    GenerateMealPlan<KetoMeal>();
                    break;
                case "High-Protein":
                    GenerateMealPlan<HighProteinMeal>();
                    break;
                default:
                    Console.WriteLine("Invalid category.");
                    break;
            }
        }

        public void GenerateMealPlan<T>() where T : IMealPlan, new()
        {
            Meal<T> meal = new Meal<T>();
            if (ValidateMealPlan(meal.MealPlan))
            {
                Console.WriteLine("Generated Meal Plan:");
                meal.DisplayMealPlan();
            }
            else
            {
                Console.WriteLine("Meal plan validation failed.");
            }
        }

        private bool ValidateMealPlan(IMealPlan mealPlan)
        {
            // Simple validation: ensure at least one ingredient
            return mealPlan.Ingredients.Count > 0;
        }
    }
}
