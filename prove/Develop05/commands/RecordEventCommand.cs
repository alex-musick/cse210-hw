public class RecordEventCommand : Command
{
    Repository _repo = new InMemRepo();
    public RecordEventCommand(Repository repo)
    {
        _repo = repo;
    }

    public override void Execute()
    {
        bool done = false;
        Goal goal = new Goal("", "", 0);
        while (!done)
        {
            new ListGoalsCommand(_repo).Execute();
            Console.WriteLine();
            Console.Write("Which goal did you complete?: ");
            string goalNumberInput = Console.ReadLine();

            try
            {
                int goalNumber = int.Parse(goalNumberInput);
                goal = _repo.GetAll()[goalNumber - 1];
                done = true;
            }
            catch
            {
                Console.WriteLine("That's not a valid goal number.");
            }
        }

        goal.RecordProgress();
        Console.WriteLine("Event recorded!");
    }
}