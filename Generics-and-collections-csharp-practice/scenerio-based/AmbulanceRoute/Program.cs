using System;

namespace AmbulanceRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList hospitalUnits = new CircularLinkedList();

            // Add hospital units in circular order
            hospitalUnits.AddUnit("Emergency");
            hospitalUnits.AddUnit("Radiology");
            hospitalUnits.AddUnit("Surgery");
            hospitalUnits.AddUnit("ICU");

            Console.WriteLine("Hospital Units Circular Route:");
            hospitalUnits.PrintUnits();

            // Simulate ambulance bringing in patients
            Console.WriteLine("\nSimulating Ambulance Navigation:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"\nPatient {i} arrival:");
                string availableUnit = hospitalUnits.FindAvailableUnit();
                if (availableUnit != null)
                {
                    Console.WriteLine($"Directed to: {availableUnit}");
                    // Mark as occupied temporarily
                    hospitalUnits.SetUnitAvailability(availableUnit, false);
                }
                else
                {
                    Console.WriteLine("No available units found.");
                }
            }

            // Simulate removing a unit for maintenance
            Console.WriteLine("\nRemoving Surgery unit for maintenance:");
            hospitalUnits.RemoveUnit("Surgery");
            hospitalUnits.PrintUnits();

            // Try finding available unit after removal
            Console.WriteLine("\nFinding available unit after maintenance:");
            string nextAvailable = hospitalUnits.FindAvailableUnit();
            if (nextAvailable != null)
            {
                Console.WriteLine($"Next available unit: {nextAvailable}");
            }
            else
            {
                Console.WriteLine("No available units.");
            }
        }
    }
}
