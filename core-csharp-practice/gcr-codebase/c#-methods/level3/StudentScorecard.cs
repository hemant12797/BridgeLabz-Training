using System;

class StudentScorecard
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        Random r = new Random();

        int[,] m = new int[n,3];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < 3; j++)
                m[i,j] = r.Next(10,99);

        for (int i = 0; i < n; i++)
        {
            int t = m[i,0] + m[i,1] + m[i,2];
            double avg = t / 3.0;
            double per = Math.Round((t / 300.0) * 100, 2);
            Console.WriteLine(m[i,0] + "\t" + m[i,1] + "\t" + m[i,2] + "\t" + t + "\t" + avg + "\t" + per);
        }
    }
}