namespace SmartWarehouseManagementSystem;

public class Groceries : WarehouseItem
{
    public DateTime ExpiryDate { get; set; }

    public Groceries(string name, double price, DateTime expiryDate) : base(name, price)
    {
        ExpiryDate = expiryDate;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Groceries: {Name}, Price: {Price}, Expiry: {ExpiryDate.ToShortDateString()}");
    }
}
