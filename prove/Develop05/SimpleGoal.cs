public class SimpleGoal : Goal
{

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordProgress()
    {
        this._complete = true;
        _earnedPoints = base.GetPoints();
    }

    public override string ToString()
    {
        String returnedString = "";
        returnedString += "type:simple|";
        returnedString += $"name:{GetName()}|";
        returnedString += $"description:{GetDesc()}|";
        returnedString += $"points:{GetPoints()}|";
        returnedString += $"earned:{GetEarnedPoints()}|";
        returnedString += $"complete:{IsComplete()}";

        return returnedString;
    }

    public override string GetGoalType()
    {
        return "simple";
    }
}