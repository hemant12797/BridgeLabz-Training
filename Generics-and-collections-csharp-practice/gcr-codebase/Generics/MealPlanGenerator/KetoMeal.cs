using System.Collections.Generic;

namespace MealPlanGenerator
{
    public class KetoMeal : IMealPlan
    {
        public string Category => "Keto";

        public List<string> Ingredients => new List<string> { "Meat", "Fish", "Eggs", "Cheese", "Avocados", "Nuts" };

        public string Description => "A low-carb, high-fat meal plan designed to induce ketosis.";
    }
}
