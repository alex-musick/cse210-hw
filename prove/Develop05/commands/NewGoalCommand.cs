public class NewGoalCommand : Command
{

    private Repository _repo = new InMemRepo();
    public NewGoalCommand(InMemRepo repo)
    {
        _repo = repo;
    }

    public override void Execute()
    {

        bool done = false;
        while (!done)
        {

            Console.WriteLine("Please choose the type of goal you wish to create.");
            Console.WriteLine("1) Simple Goal");
            Console.WriteLine("2) Eternal Goal");
            Console.WriteLine("3) Checklist Goal");
            Console.Write(">");
            string userChoice = Console.ReadLine();

            switch(userChoice)
            {
                case("1"):
                {
                    _repo.Add(NewSimpleGoal());
                    done = true;
                    break;
                }
                case("2"):
                {
                    _repo.Add(NewEternalGoal());
                    done = true;
                    break;
                }
                case("3"):
                {
                    _repo.Add(NewChecklistGoal());
                    done = true;
                    break;
                }
                default:
                {
                    Console.WriteLine("That's not a valid option.");
                    Console.WriteLine();
                    break;
                }
            }
        }
    }

    private Goal NewSimpleGoal()
    {
        Console.Write("Type the name of this goal: ");
        string goalName = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Type the description for this goal: ");
        string goalDesc = Console.ReadLine();
        Console.WriteLine();
        
        int goalPoints = 0;

        while (true)
        {
            Console.Write("Type the number of points this goal is worth: ");
            string goalPointsInput = Console.ReadLine();
            Console.WriteLine();
            try
            {
                goalPoints = int.Parse(goalPointsInput);
                break;
            }
            catch
            {
                Console.WriteLine("Sorry, that's not a valid number of points.");
            }
        }

        return new SimpleGoal(goalName, goalDesc, goalPoints);
    }
    private Goal NewEternalGoal()
    {
        Console.Write("Type the name of this goal: ");
        string goalName = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Type the description for this goal: ");
        string goalDesc = Console.ReadLine();
        Console.WriteLine();
        
        int goalPoints = 0;

        while (true)
        {
            Console.Write("Type the number of points this goal is worth per completion: ");
            string goalPointsInput = Console.ReadLine();
            Console.WriteLine();
            try
            {
                goalPoints = int.Parse(goalPointsInput);
                break;
            }
            catch
            {
                Console.WriteLine("Sorry, that's not a valid number of points.");
            }
        }

        return new EternalGoal(goalName, goalDesc, goalPoints);
    }
    private Goal NewChecklistGoal()
    {
        Console.Write("Type the name of this goal: ");
        string goalName = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Type the description for this goal: ");
        string goalDesc = Console.ReadLine();
        Console.WriteLine();
        
        int goalInstancePoints = 0;

        while (true)
        {
            Console.Write("Type the number of points this goal is worth per event: ");
            string goalPointsInput = Console.ReadLine();
            Console.WriteLine();
            try
            {
                goalInstancePoints = int.Parse(goalPointsInput);
                break;
            }
            catch
            {
                Console.WriteLine("Sorry, that's not a valid number of points.");
            }
        }

        int goalCompletionPoints = 0;

        while (true)
        {
            Console.Write("Type the number of points to award when the goal is fully completed: ");
            string goalPointsInput = Console.ReadLine();
            Console.WriteLine();
            try
            {
                goalCompletionPoints = int.Parse(goalPointsInput);
                break;
            }
            catch
            {
                Console.WriteLine("Sorry, that's not a valid number of points.");
            }
        }

        int timesRequired = 0;

        while (true)
        {
            Console.Write("Type the number of times this goal must be done before being complete: ");
            string goalPointsInput = Console.ReadLine();
            Console.WriteLine();
            try
            {
                timesRequired = int.Parse(goalPointsInput);
                break;
            }
            catch
            {
                Console.WriteLine("Sorry, that's not a valid number of times.");
            }
        }

        return new ChecklistGoal(goalName, goalDesc, goalInstancePoints, goalCompletionPoints, timesRequired);
    }

}