
using System;
class Program
{
    static void Main()
    {
        Vehicle.UpdateRegistrationFee(2000);
        Vehicle v = new Vehicle("Ashish", "Car");
        v.DisplayVehicleDetails();
    }
}
