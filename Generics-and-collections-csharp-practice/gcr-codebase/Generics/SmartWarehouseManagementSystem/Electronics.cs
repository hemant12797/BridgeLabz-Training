namespace SmartWarehouseManagementSystem;

public class Electronics : WarehouseItem
{
    public string Brand { get; set; }

    public Electronics(string name, double price, string brand) : base(name, price)
    {
        Brand = brand;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Electronics: {Name}, Price: {Price}, Brand: {Brand}");
    }
}
