using System;
using System.Collections.Generic;

namespace VehicleRentalSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            Car car = new Car { VehicleNumber = "ABC123", Type = "Sedan", RentalRate = 50 };
            car.InsurancePolicy = "POL123";
            vehicles.Add(car);

            Bike bike = new Bike { VehicleNumber = "XYZ456", Type = "Motorcycle", RentalRate = 20 };
            bike.InsurancePolicy = "POL456";
            vehicles.Add(bike);

            Truck truck = new Truck { VehicleNumber = "DEF789", Type = "Pickup", RentalRate = 80 };
            truck.InsurancePolicy = "POL789";
            vehicles.Add(truck);

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"Vehicle: {vehicle.VehicleNumber}, Type: {vehicle.Type}");
                Console.WriteLine($"Rental Cost for 5 days: {vehicle.CalculateRentalCost(5)}");
                if (vehicle is IInsurable insurable)
                {
                    Console.WriteLine($"Insurance Cost: {insurable.CalculateInsurance()}");
                    Console.WriteLine(insurable.GetInsuranceDetails());
                }
                Console.WriteLine();
            }
        }
    }
}
