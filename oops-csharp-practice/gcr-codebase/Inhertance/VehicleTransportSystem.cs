
class Vehicle
{
    public int MaxSpeed;
    public string FuelType;

    public virtual void DisplayInfo()
    {
        System.Console.WriteLine(MaxSpeed + " " + FuelType);
    }
}

class Car : Vehicle
{
    public int SeatCapacity;
    public override void DisplayInfo()
    {
        System.Console.WriteLine(MaxSpeed + " " + FuelType + " Seats:" + SeatCapacity);
    }
}

class Truck : Vehicle
{
    public int PayloadCapacity;
    public override void DisplayInfo()
    {
        System.Console.WriteLine(MaxSpeed + " " + FuelType + " Payload:" + PayloadCapacity);
    }
}

class Motorcycle : Vehicle
{
    public bool HasSidecar;
    public override void DisplayInfo()
    {
        System.Console.WriteLine(MaxSpeed + " " + FuelType + " Sidecar:" + HasSidecar);
    }
}
