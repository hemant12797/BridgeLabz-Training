using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

class Program
{
    static void Main()
    {
        string jsonIn = "input.json";
        string jsonOut = "output.json";
        string csvIn = "input.csv";
        string csvOut = "output.csv";

        File.WriteAllText(jsonIn,
@"[
 { ""match_id"":101,""team1"":""Mumbai Indians"",""team2"":""Chennai Super Kings"",
   ""score"":{""Mumbai Indians"":178,""Chennai Super Kings"":182},
   ""winner"":""Chennai Super Kings"",""player_of_match"":""MS Dhoni""},
 { ""match_id"":102,""team1"":""Royal Challengers Bangalore"",""team2"":""Delhi Capitals"",
   ""score"":{""Royal Challengers Bangalore"":200,""Delhi Capitals"":190},
   ""winner"":""Royal Challengers Bangalore"",""player_of_match"":""Virat Kohli""}
]"
        );

        JsonArray arr = JsonNode.Parse(File.ReadAllText(jsonIn)).AsArray();
        JsonArray outArr = new JsonArray();

        foreach (JsonObject o in arr)
        {
            string t1 = Mask(o["team1"].ToString());
            string t2 = Mask(o["team2"].ToString());

            JsonObject score = new JsonObject();
            foreach (var s in o["score"].AsObject())
                score[Mask(s.Key)] = s.Value.DeepClone();

            outArr.Add(new JsonObject
            {
                ["match_id"] = o["match_id"].DeepClone(),
                ["team1"] = t1,
                ["team2"] = t2,
                ["score"] = score,
                ["winner"] = Mask(o["winner"].ToString()),
                ["player_of_match"] = "REDACTED"
            });
        }

        File.WriteAllText(jsonOut, outArr.ToJsonString());

        File.WriteAllText(csvIn,
@"match_id,team1,team2,score_team1,score_team2,winner,player_of_match
101,Mumbai Indians,Chennai Super Kings,178,182,Chennai Super Kings,MS Dhoni
102,Royal Challengers Bangalore,Delhi Capitals,200,190,Royal Challengers Bangalore,Virat Kohli"
        );

        string[] lines = File.ReadAllLines(csvIn);
        using StreamWriter w = new StreamWriter(csvOut);
        w.WriteLine(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] p = lines[i].Split(',');
            w.WriteLine(
                p[0] + "," +
                Mask(p[1]) + "," +
                Mask(p[2]) + "," +
                p[3] + "," +
                p[4] + "," +
                Mask(p[5]) + "," +
                "REDACTED"
            );
        }
    }

    static string Mask(string s)
    {
        int i = s.IndexOf(' ');
        return i == -1 ? "***" : s.Substring(0, i) + " ***" + s.Substring(s.LastIndexOf(' '));
    }
}
