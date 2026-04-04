public class AC : Appliance
{
    public override void TurnOn()
    {
        Console.WriteLine("AC is cooling");
    }

    public override void TurnOff()
    {
        Console.WriteLine("AC is off");
    }
}
