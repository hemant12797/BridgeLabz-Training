
class Vehicle
{
    public static double RegistrationFee = 2000;

    public string OwnerName;
    public readonly string RegistrationNumber;
    public string VehicleType;

    public Vehicle(string owner, string regNo, string type)
    {
        this.OwnerName = owner;
        this.RegistrationNumber = regNo;
        this.VehicleType = type;
    }

    public static void UpdateRegistrationFee(double fee)
    {
        RegistrationFee = fee;
    }

    public void Display(object obj)
    {
        if (obj is Vehicle)
            System.Console.WriteLine(OwnerName + " " + RegistrationNumber + " " + VehicleType);
    }
}
