using System;

class Program
{
    static void Main()
    {
        HotelBooking hb = new HotelBooking("Ashish", "Deluxe", 3);
        Console.WriteLine(hb.GuestName + " " + hb.RoomType + " " + hb.Nights);
    }
}
