public class Light : Appliance
{
    public override void TurnOn()
    {
        Console.WriteLine("Light is turned on");
    }

    public override void TurnOff()
    {
        Console.WriteLine("Light is turned off");
    }
}
