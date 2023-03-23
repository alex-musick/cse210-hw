public class SaveGoalsCommand : Command
{
    private Repository _repo = new InMemRepo();
    public SaveGoalsCommand(Repository repo)
    {
        _repo = repo;
    }

    public override void Execute()
    {
        string fileName = GetFileName();
        TextFileRepo scribe = new TextFileRepo();
        scribe.SetFileName(fileName);
        foreach(Goal goal in _repo.GetAll())
        {
            scribe.Add(goal);
        }
    }

    private string GetFileName()
    {
        string fileName = "";
        while (fileName == "")
        {
            Console.Write("Type the file name you want to save to (will be overwritten): ");
            fileName = Console.ReadLine();
            if (fileName == "")
            {
                Console.WriteLine("Please type a file name.");
            }
        }
        return fileName;
    }
}