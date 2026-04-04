using System.Collections.Generic;

namespace MealPlanGenerator
{
    public class VeganMeal : IMealPlan
    {
        public string Category => "Vegan";

        public List<string> Ingredients => new List<string> { "Vegetables", "Fruits", "Grains", "Legumes", "Nuts", "Seeds" };

        public string Description => "A plant-based meal plan that excludes all animal products.";
    }
}
