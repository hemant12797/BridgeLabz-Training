class CarRental
{
    public string CustomerName;
    public string CarModel;
    public int RentalDays;
    public double CostPerDay = 1000;

    public CarRental(string name, string model, int days)
    {
        CustomerName = name;
        CarModel = model;
        RentalDays = days;
    }

    public double TotalCost()
    {
        return RentalDays * CostPerDay;
    }
}
