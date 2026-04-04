using System.Collections.Generic;

namespace MealPlanGenerator
{
    public interface IMealPlan
    {
        string Category { get; }
        List<string> Ingredients { get; }
        string Description { get; }
    }
}
