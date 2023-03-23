public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordProgress()
    {
        _complete = false; // For redundancy. In reality _complete should always be false
        _earnedPoints += GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string ToString()
    {
        String returnedString = "";
        returnedString += "type:eternal|";
        returnedString += $"name:{GetName()}|";
        returnedString += $"description:{GetDesc()}|";
        returnedString += $"points:{GetPoints()}|";
        returnedString += $"earned:{GetEarnedPoints()}|";
        returnedString += "complete:false";

        return returnedString;
    }

    public override string GetGoalType()
    {
        return "eternal";
    }
}