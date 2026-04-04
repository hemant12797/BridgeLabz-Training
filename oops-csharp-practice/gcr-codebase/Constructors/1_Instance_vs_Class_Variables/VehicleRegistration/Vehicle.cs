
class Vehicle
{
    public string ownerName;
    public string vehicleType;
    public static double registrationFee = 1500;

    public Vehicle(string owner, string type)
    {
        ownerName = owner;
        vehicleType = type;
    }

    public void DisplayVehicleDetails()
    {
        System.Console.WriteLine(ownerName + " " + vehicleType + " " + registrationFee);
    }

    public static void UpdateRegistrationFee(double fee)
    {
        registrationFee = fee;
    }
}
