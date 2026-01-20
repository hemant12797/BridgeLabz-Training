namespace MealPlanGenerator
{
    public class Meal<T> where T : IMealPlan, new()
    {
        public T MealPlan { get; private set; }

        public Meal()
        {
            MealPlan = new T();
        }

        public void DisplayMealPlan()
        {
            Console.WriteLine($"Category: {MealPlan.Category}");
            Console.WriteLine($"Description: {MealPlan.Description}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in MealPlan.Ingredients)
            {
                Console.WriteLine($"- {ingredient}");
            }
        }
    }
}
