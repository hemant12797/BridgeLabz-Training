using System.Collections.Generic;

namespace MealPlanGenerator
{
    public class VegetarianMeal : IMealPlan
    {
        public string Category => "Vegetarian";

        public List<string> Ingredients => new List<string> { "Eggs", "Cheese", "Vegetables", "Grains" };

        public string Description => "A meal plan that includes eggs, dairy, vegetables, and grains, but no meat.";
    }
}
