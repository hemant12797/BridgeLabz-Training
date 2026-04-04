using System;
namespace ParcelTracker
{
    internal class Menu
    {
        public static void Display()
        {
            ITracker obj = new Utility();
            do
            {
                Console.WriteLine("\n1 Add Parcel");
                Console.WriteLine("2 Update Stage");
                Console.WriteLine("3 Track Parcel");
                Console.WriteLine("4 Track All");
                Console.WriteLine("5 Exit");

                int ch = int.Parse(Console.ReadLine());

                if (ch == 1) obj.AddParcel();
                else if (ch == 2) obj.UpdateStage();
                else if (ch == 3) obj.TrackParcel();
                else if (ch == 4) obj.TrackAll();
                else break;

            } while (true);
        }
    }
}