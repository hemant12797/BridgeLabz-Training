internal class StepsTrackerMenu
{
    private IStepsTracker stepsTrackerUtility;

    public void ShowStepsTrackerMenu()
    {
        stepsTrackerUtility = new StepsTrackerUtility();
        int choice;
        do
        {
            Console.WriteLine("\n==== STEPS TRACKER ====\n");
            Console.WriteLine("1. Show Leaderboard");
            Console.WriteLine("2. Add an athlete");
            Console.WriteLine("3. Update step count");
            Console.WriteLine("0. Exit");
            Console.Write("\nEnter your choice number: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            switch (choice)
            {
                case 1:
                    stepsTrackerUtility.ShowLeaderBoard();
                    break;
                case 2:
                    stepsTrackerUtility.AddAnAthlete();
                    break;
                case 3:
                    stepsTrackerUtility.UpdateAthleteStepCount();
                    break;
            }

        } while (choice != 0);
    }
}