
interface Refuelable
{
    void Refuel();
}

class Vehicle
{
    public int MaxSpeed;
    public string Model;
}

class ElectricVehicle : Vehicle
{
    public void Charge()
    {
        System.Console.WriteLine("Charging vehicle");
    }
}

class PetrolVehicle : Vehicle, Refuelable
{
    public void Refuel()
    {
        System.Console.WriteLine("Refueling vehicle");
    }
}
