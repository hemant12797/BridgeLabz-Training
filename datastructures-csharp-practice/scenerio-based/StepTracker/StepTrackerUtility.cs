using System.Reflection.Metadata;

internal class StepsTrackerUtility: IStepsTracker
{
    private Athlete[] _athletesList;
    private int _athletesListIndex;

    public StepsTrackerUtility()
    {
        int maxSize = 20;
        _athletesList = new Athlete[maxSize];
        _athletesListIndex = 0;
    }

    public void ShowLeaderBoard()
    {
        Console.WriteLine("\n========== LEADERBOARD ==========\n");
        if(_athletesListIndex == 0)
        {
            Console.WriteLine("\nAthletes data not available...\n");
            return;
        }

        Console.WriteLine("Here's the leaderboard:\n");
        for(int i = 0; i < _athletesListIndex; i++)
        {
            Console.WriteLine(_athletesList[i]);
        }
        Console.WriteLine("\n");
    }

    public void AddAnAthlete()
    {
        Console.WriteLine("\n==== ATHLETE ADDITION WINDOW ====\n");
        if (_athletesListIndex >= _athletesList.Length)
        {
            Console.WriteLine("\nMaximum capacity reached...\n");
            return;
        }

        Console.Write("Enter athlete name: ");
        string athleteName = Console.ReadLine();
        Console.Write("Enter athlete step count: ");
        int athleteStepCount = int.Parse(Console.ReadLine());

        Athlete athlete = new Athlete(athleteName, athleteStepCount);
        _athletesList[_athletesListIndex++] = athlete;

        BubbleSort();

        Console.WriteLine("\nAthlete added successfully...\n");
    }
    
    public void UpdateAthleteStepCount()
    {
        Console.WriteLine("\n==== ATHLETE STEPS UPDATION WINDOW ====\n");
        Console.Write("Enter athelete name: ");
        string athleteName = Console.ReadLine();

        Athlete athlete = FindAthlete(athleteName);

        if(athlete == null)
        {
            Console.WriteLine("\nAthlete not found...\n");
            return;
        }

        Console.Write("Enter updated step count: ");
        int updatedStepCount = int.Parse(Console.ReadLine());
        athlete.SetAthleteStepCount(updatedStepCount);
        BubbleSort();
        Console.WriteLine("\nStep count updated successfully...\n");
    }

    private Athlete FindAthlete(string athleteName)
    {
        for(int i = 0; i < _athletesListIndex; i++)
        {
            if (_athletesList[i].GetAthleteName().Equals(athleteName))
            {
                return _athletesList[i];
            }
        }

        return null;
    }
    private void BubbleSort()
    {
        for(int i = 0; i < _athletesListIndex-1; i++)
        {
            bool swapped = false;
            for(int j = 0; j < _athletesListIndex-i-1; j++)
            {
                if (_athletesList[j].GetAthleteStepCount() < _athletesList[j+1].GetAthleteStepCount())
                {
                    Athlete temp = _athletesList[j];
                    _athletesList[j] = _athletesList[j + 1];
                    _athletesList[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped) break;
        }
    }
    
}