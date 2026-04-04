
class Device
{
    public int DeviceId;
    public string Status;

    public virtual void DisplayStatus()
    {
        System.Console.WriteLine(DeviceId + " " + Status);
    }
}

class Thermostat : Device
{
    public int TemperatureSetting;

    public override void DisplayStatus()
    {
        System.Console.WriteLine(DeviceId + " " + Status + " Temp:" + TemperatureSetting);
    }
}
