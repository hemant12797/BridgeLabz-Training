using System;

namespace MealPlanGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Personalized Meal Plan Generator!");
            Console.WriteLine("Choose a meal category:");
            Console.WriteLine("1. Vegetarian");
            Console.WriteLine("2. Vegan");
            Console.WriteLine("3. Keto");
            Console.WriteLine("4. High-Protein");
            Console.Write("Enter your choice (1-4): ");

            string choice = Console.ReadLine();
            string category = choice switch
            {
                "1" => "Vegetarian",
                "2" => "Vegan",
                "3" => "Keto",
                "4" => "High-Protein",
                _ => null
            };

            if (category == null)
            {
                Console.WriteLine("Invalid choice. Exiting.");
                return;
            }

            MealPlanGeneratorService generator = new MealPlanGeneratorService();
            generator.GenerateMealPlan(category);
        }
    }
}
