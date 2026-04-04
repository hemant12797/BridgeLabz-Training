
using System;

namespace ParcelTracker
{
    internal class Parcel
    {
        public string Id;
        public Stage Head;
        public Stage Track;

        public Parcel(string id)
        {
            Id = id;
            Head = new Stage("Packed");
            Track = Head;
            Head.Next = new Stage("Shipped");
            Head.Next.Next = new Stage("InTrasit");
            Head.Next.Next.Next = new Stage("Delivered");

        }

        public override string ToString()
        {
            Stage temp = Head;
            string ans = "";
            while (temp != Track.Next)
            {
                ans += temp.Name + " -> ";
                temp = temp.Next;
            }
            ans += "END";
            return $"Parcel ID : {Id}\nTracker : {ans}";
        }
    }

    internal class Stage
    {
        public string Name;
        public Stage Next;

        public Stage(string name)
        {
            Name = name;
            Next = null;
        }
    }
}