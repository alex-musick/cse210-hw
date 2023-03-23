public class Goal
{
    private string _name = "";
    private string _description = "";
    private int _points = 0;
    protected int _earnedPoints = 0;
    protected bool _complete = false;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;

    }

    public string GetName()
    {
        return _name;
    }

    public string GetDesc()
    {
        return _description;
    }

    public virtual int GetPoints()
    {
        return _points;
    }

    public int GetEarnedPoints()
    {
        return _earnedPoints;
    }

    public virtual void RecordProgress()
    {
        throw new Exception("Can't record progress on non-specific goal class");
    }

    public virtual bool IsComplete()
    {
        return _complete;
    }

    public void MarkComplete()
    {
        _complete = true;
    }

    public void OverrideEarnedPoints(int earnedPoints)
    {
        _earnedPoints = earnedPoints;
    }

    public virtual string GetGoalType()
    {
        return "base";
    }

    public override string ToString()
    {
        throw new Exception("Can't convert a member of base goal class to a string.");
    }

    //These two are only relevant to ChecklistGoal but are needed to allow for running these commands on generic types
    public virtual int GetTimesRecorded()
    {
        throw new NotImplementedException();
    }

    public virtual int GetTimesRequired()
    {
        throw new NotImplementedException();
    }
}