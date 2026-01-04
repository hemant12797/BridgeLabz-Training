
class Order
{
    public int OrderId;
    public string OrderDate;

    public virtual string GetOrderStatus()
    {
        return "Order Placed";
    }
}

class ShippedOrder : Order
{
    public string TrackingNumber;

    public override string GetOrderStatus()
    {
        return "Order Shipped";
    }
}

class DeliveredOrder : ShippedOrder
{
    public string DeliveryDate;

    public override string GetOrderStatus()
    {
        return "Order Delivered";
    }
}
