
using System.IO;
using System.Linq;

class MergeCSV
{
    static void Main()
    {
        var a = File.ReadAllLines("students1.csv").Skip(1)
                    .Select(l => l.Split(','));
        var b = File.ReadAllLines("students2.csv").Skip(1)
                    .Select(l => l.Split(','));

        var merged =
            from x in a
            join y in b on x[0] equals y[0]
            select $"{x[0]},{x[1]},{x[2]},{y[1]},{y[2]}";

        File.WriteAllLines("merged.csv", merged);
    }
}
