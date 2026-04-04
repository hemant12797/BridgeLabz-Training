class HotelBooking
{
    public string GuestName;
    public string RoomType;
    public int Nights;

    public HotelBooking()
    {
        GuestName = "Guest";
        RoomType = "Standard";
        Nights = 1;
    }

    public HotelBooking(string name, string room, int nights)
    {
        GuestName = name;
        RoomType = room;
        Nights = nights;
    }

    public HotelBooking(HotelBooking hb)
    {
        GuestName = hb.GuestName;
        RoomType = hb.RoomType;
        Nights = hb.Nights;
    }
}
