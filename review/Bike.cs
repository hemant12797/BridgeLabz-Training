using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeRentalApp
{
    public class Bike
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int PricePerDay { get; set; }
    }

    public class BikeUtility
    {
        public void AddBikeDetails(string model, string brand, int pricePerDay)
        {
            Bike newBike = new Bike 
            { 
                Model = model, 
                Brand = brand, 
                PricePerDay = pricePerDay 
            };
            int newKey = Program.bikeDetails.Count + 1;
            Program.bikeDetails.Add(newKey, newBike);
            
            Console.WriteLine("Bike added ");
        }

        public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
        {
            SortedDictionary<string, List<Bike>> groupedBikes = new SortedDictionary<string, List<Bike>>();

            foreach (var bike in Program.bikeDetails.Values)
            {
                if (!groupedBikes.ContainsKey(bike.Brand))
                {
                    groupedBikes[bike.Brand] = new List<Bike>();
                }
                groupedBikes[bike.Brand].Add(bike);
            }

            return groupedBikes;
        }
    }

    public class Program
    {
        public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();

        public static void Main(string[] args)
        {
            BikeUtility utility = new BikeUtility();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Add Bike Details");
                Console.WriteLine("2. Group Bikes By Brand");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("Enter no: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Write("model: ");
                    string model = Console.ReadLine();
                    Console.Write("brand: ");
                    string brand = Console.ReadLine();
                    Console.Write("price per day: ");
                    int price = int.Parse(Console.ReadLine());
                    utility.AddBikeDetails(model, brand, price);
                    Console.WriteLine();
                }
                else if (choice == "2")
                {
                    var grouped = utility.GroupBikesByBrand();
                    foreach (var kvp in grouped)
                    {
                        Console.WriteLine(kvp.Key);
                        foreach (var bike in kvp.Value)
                        {
                            Console.WriteLine(bike.Model);
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == "3")
                {
                    exit = true;
                }
            }
        }
    }
}









