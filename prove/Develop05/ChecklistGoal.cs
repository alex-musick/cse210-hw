public class ChecklistGoal : Goal
{

    private int _instancePoints = 0; //Number of points to be given when one instance of the task is completed, but not the entire task of doing the action several times
    private int _timesRequired = 1;
    private int _pointsIfComplete = 0; //Number of points when the next recorded porgress will mark full completion
    public ChecklistGoal(string name, string description, int instancePoints, int finalPoints, int timesRequired) : base(name, description, finalPoints)
    {
        _instancePoints = instancePoints;
        _timesRequired = timesRequired;

        _pointsIfComplete = _instancePoints * (_timesRequired - 1);
    }

    private int GetFinalPoints() //For readability
    {
        return GetPoints();
    }

    public override void RecordProgress()
    {
        if (IsComplete() == true)
        {
            return;
        }

        if (GetEarnedPoints() >= _pointsIfComplete)
        {
            this._complete = true;
            base._earnedPoints += GetFinalPoints();
        }
        else
        {
            this._complete = false; //For redundancy, it should actually already be false in this case
            base._earnedPoints += _instancePoints;
        }
    }

    public override int GetTimesRecorded()
    {
        if (GetEarnedPoints() == 0)
        {
            return 0;
        }
        if (GetEarnedPoints() % _instancePoints == 0 & GetEarnedPoints() <= _pointsIfComplete)
        {
            return GetEarnedPoints() / _instancePoints;
        }
        if (GetEarnedPoints() == _instancePoints * (_timesRequired - 1) + GetFinalPoints())
        {
            return _timesRequired;
        }

        throw new Exception($"Number of earned points is invalid for {GetName()} ({GetEarnedPoints()}), can't calculate number of instances completed.");
    }

    public override int GetTimesRequired()
    {
        return _timesRequired;
    }

    public override string ToString()
    {
        String returnedString = "";
        returnedString += "type:checklist|";
        returnedString += $"name:{GetName()}|";
        returnedString += $"description:{GetDesc()}|";
        returnedString += $"points:{GetPoints()}|";
        returnedString += $"earned:{GetEarnedPoints()}|";
        returnedString += $"complete:{IsComplete()}|";
        returnedString += $"instancepoints:{_instancePoints}|";
        returnedString += $"timesrequired:{_timesRequired}";

        return returnedString;
    }

    public override string GetGoalType()
    {
        return "checklist";
    }
}