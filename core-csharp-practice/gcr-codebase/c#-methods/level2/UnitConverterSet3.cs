using System;

class UnitConverterSet3
{
    static double FToC(double f) { return (f - 32) * 5 / 9; }
    static double CToF(double c) { return (c * 9 / 5) + 32; }
    static double PoundsToKg(double p) { return p * 0.453592; }
    static double KgToPounds(double k) { return k * 2.20462; }
    static double GallonsToLiters(double g) { return g * 3.78541; }
    static double LitersToGallons(double l) { return l * 0.264172; }

    static void Main()
    {
        double v = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(FToC(v));
        Console.WriteLine(CToF(v));
        Console.WriteLine(PoundsToKg(v));
        Console.WriteLine(KgToPounds(v));
        Console.WriteLine(GallonsToLiters(v));
        Console.WriteLine(LitersToGallons(v));
    }
}