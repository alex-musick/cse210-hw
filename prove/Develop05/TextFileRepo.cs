using System.IO;

public class TextFileRepo : Repository
{
    private string _fileName = "goals.txt";

    public override void Add(Goal goal)
    {
        using (StreamWriter fileName = new StreamWriter(_fileName, true))
        {
            fileName.WriteLine(goal.ToString());
        }
    }

    public override void Remove(Goal goal)
    {
        InMemRepo inMemRepo = new InMemRepo();
        foreach (Goal savedGoal in this.GetAll())
        {
            inMemRepo.Add(savedGoal);
        }
        inMemRepo.Remove(goal);

        File.Delete(_fileName);

        foreach (Goal loadedGoal in inMemRepo.GetAll())
        {
            this.Add(loadedGoal);
        }
    }

    private Goal ParseGoalFromText(string line)
    {
        Goal loadedGoal;
        List<string> attribute = GetAttributeValues(line);
        string type = attribute[0];
        string name = attribute[1];
        string description = attribute[2];
        int points = int.Parse(attribute[3]);
        int earned = int.Parse(attribute[4]);
        string complete = attribute[5];

        switch(type)
        {
            case("simple"):
            {
                loadedGoal = new SimpleGoal(name, description, points);
                break;
            }
            case("eternal"):
            {
                loadedGoal = new EternalGoal(name, description, points);
                break;
            }
            case("checklist"):
            {
                int instancePoints = int.Parse(attribute[6]);
                int timesRequired = int.Parse(attribute[7]);
                loadedGoal = new ChecklistGoal(name, description, instancePoints, points, timesRequired);
                break;
            }
            default:
            {
                throw new Exception($"Goal with name {name} from {_fileName} has invalid type {type}");
            }
        }

        loadedGoal.OverrideEarnedPoints(earned);
        if (complete == "true")
        {
            loadedGoal.MarkComplete();
        }

        return loadedGoal;
    }

    private List<string> GetAttributeValues(string line)
    {
        List<string> returnedList = new List<string>();
        string[] attributes = line.Split("|");
        foreach (string attribute in attributes)
        {
            string[] attributeValues = attribute.Split(":");
            if (attributeValues.Count() < 2)
            {
                break;
            }
            returnedList.Add(attributeValues[1]);
        }
        return returnedList;
    }

    public override List<Goal> GetAll()
    {
        string[] lines = File.ReadAllLines(_fileName);
        List<Goal> returnedList = new List<Goal>();
        
        foreach (string line in lines)
        {
            Goal currentGoal = ParseGoalFromText(line);
            returnedList.Add(currentGoal);
        }

        return returnedList;
    }

    public void SetFileName(string fileName)
    {
        _fileName = fileName;
    }
}