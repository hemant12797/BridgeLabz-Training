using System;

namespace VehicleRentalSystem
{
    public class Car : Vehicle, IInsurable
    {
        private string insurancePolicy;

        public string InsurancePolicy
        {
            get { return insurancePolicy; }
            set { insurancePolicy = value; }
        }

        public override double CalculateRentalCost(int days)
        {
            return RentalRate * days;
        }

        public double CalculateInsurance()
        {
            return RentalRate * 0.1;
        }

        public string GetInsuranceDetails()
        {
            return $"Insurance Policy: {InsurancePolicy}";
        }
    }
}
