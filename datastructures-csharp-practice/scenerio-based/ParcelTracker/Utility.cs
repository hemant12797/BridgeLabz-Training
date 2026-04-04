
using System;
using System.Collections.Generic;

namespace ParcelTracker
{
    internal class Utility : ITracker
    {
        Dictionary<string,Parcel> parcels = new Dictionary<string, Parcel>();

        public void AddParcel()
        {
            Console.Write("Enter Parcel ID: ");
            string id = Console.ReadLine();
            if (parcels.ContainsKey(id)) { 
                Console.WriteLine("\nProduct Is Already Exist");
                Console.WriteLine(parcels[id]);
                return;
            }
            parcels.Add(id,new Parcel(id));
            Console.WriteLine("\nParcel Added Successfully.\n");
        }

        public void UpdateStage()
        {
            Console.Write("Enter Parcel ID: ");
            string id = Console.ReadLine();
            if (!parcels.ContainsKey(id))
            {
                Console.WriteLine("Parcel Is Not Available");
                return;
            }
            Parcel p = parcels[id];
            if (p.Track.Name.Equals("Delivered")) Console.WriteLine("Package Is Already Delivered");
            else
            {
                p.Track = p.Track.Next;
                Console.WriteLine("\nStage Update Successfully\n");
            }
        }

        public void TrackParcel()
        {
            Console.Write("Enter Parcel ID: ");
            string id = Console.ReadLine();
            if (parcels.ContainsKey(id)) Console.WriteLine($"\n{parcels[id]}");
            else Console.WriteLine("Parcel Is Not Avaiable");
        }

        public void TrackAll()
        {
            Console.WriteLine("\nProcessing....\n");
            foreach (var p in parcels)
            {
                Console.Write(p.Value);
                Console.WriteLine("\n-------------------");
            }
            Console.WriteLine();
        }
    }
}