public class LoadGoalsCommand : Command
{
    Repository _repo = new InMemRepo();

    public LoadGoalsCommand(Repository repo)
    {
        _repo = repo;
    }

    public override void Execute()
    {
        string fileName = GetFileName();
        TextFileRepo scribe = new TextFileRepo();
        scribe.SetFileName(fileName);
        foreach (Goal goal in scribe.GetAll())
        {
            _repo.Add(goal);
        }
    }

    private string GetFileName()
    {
        string fileName = "";
        while (fileName == "")
        {
            Console.Write("Type the file name you want to load: ");
            fileName = Console.ReadLine();
            if (fileName == "")
            {
                Console.WriteLine("Please type a file name.");
            }
        }
        return fileName;
    }
}