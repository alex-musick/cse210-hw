public class PrintTotalPointsCommand : Command
{

    private Repository _repo = new InMemRepo();
    public PrintTotalPointsCommand(Repository repo)
    {
        _repo = repo;
    }
    public override void Execute()
    {
        int total = 0;
        foreach(Goal goal in _repo.GetAll())
        {
            total += goal.GetEarnedPoints();
        }
        Console.WriteLine($"You have {total} points.");
    }

}