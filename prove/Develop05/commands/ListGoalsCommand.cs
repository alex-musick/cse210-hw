public class ListGoalsCommand : Command
{

    private Repository _repo = new InMemRepo();

    public ListGoalsCommand(Repository repo)
    {
        _repo = repo;
    }

    public override void Execute()
    {
        Console.WriteLine("Your goals are:");
        int goalNumber = 0;
        foreach (Goal goal in _repo.GetAll())
        {
            goalNumber += 1;
            Console.Write($"{goalNumber}. ");
            switch(goal.GetGoalType())
            {
                case("simple"):
                {
                    Console.Write(ListSimpleGoal(goal));
                    break;
                }
                case("eternal"):
                {
                    Console.Write(ListEternalGoal(goal));
                    break;
                }
                case("checklist"):
                {
                    Console.Write(ListChecklistGoal(goal));
                    break;
                }
            }
            Console.WriteLine();
        }
    }

    private string ListSimpleGoal(Goal goal)
    {
        string returnedString = "";
        switch(goal.IsComplete())
        {
            case (true):
                returnedString += "[X] ";
                break;
            case (false):
                returnedString += "[ ] ";
                break;
        }

        returnedString += goal.GetName() + " ";
        returnedString += $"({goal.GetDesc()})";

        return returnedString;
    }

    private string ListEternalGoal(Goal goal)
    {
        string returnedString = "";
        returnedString += goal.GetName() + " ";
        returnedString += $"({goal.GetDesc()}) ";
        returnedString += $"Done {goal.GetEarnedPoints() / goal.GetPoints()} times";
        return returnedString;
    }

    private string ListChecklistGoal(Goal goal)
    {
        string returnedString = "";

        switch(goal.IsComplete())
        {
            case (true):
                returnedString += "[X] ";
                break;
            case (false):
                returnedString += "[ ] ";
                break;
        }

        returnedString += $"({goal.GetTimesRecorded()}/{goal.GetTimesRequired()}) ";
        returnedString += goal.GetName() + " ";
        returnedString += $"({goal.GetDesc()})";
        return returnedString;
    }



}