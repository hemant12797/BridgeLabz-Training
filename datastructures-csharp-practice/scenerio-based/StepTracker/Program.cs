internal class Athlete
{
    private string _athleteName;
    private int _athleteStepCount;

    public Athlete(string athleteName, int athleteStepCount)
    {
        _athleteName = athleteName;
        _athleteStepCount = athleteStepCount;
    }

    public int GetAthleteStepCount()
    {
        return _athleteStepCount;
    }

    public string GetAthleteName()
    {
        return _athleteName;
    }

    public void SetAthleteStepCount(int athleteStepCount)
    {
        _athleteStepCount = athleteStepCount;
    }

    public override string ToString()
    {
        return $"\n{_athleteName} | {_athleteStepCount}\n";
    }
}