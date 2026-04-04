using System;

namespace ECommercePlatform
{
    public class Groceries : Product
    {
        public override double CalculateDiscount()
        {
            return Price * 0.02;
        }
    }
}
