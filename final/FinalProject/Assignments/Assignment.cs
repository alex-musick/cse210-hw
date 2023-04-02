[Serializable]
public class Assignment
{
    protected string _type = "base";
    private string _name = "";
    private double _points = 0;
    protected int _pointsModifier = 1;
    private int _credits = 0;
    private DateTime _dueDate = DateTime.Today;
    private double _rank = 0;
    private bool _isOverdue = false;

    public Assignment(string name, double points, int credits, DateTime dueDate)
    {
        _name = name;
        _points = points;
        _credits = credits;
        _dueDate = dueDate;
    }

    public void Rank()
    {
        TimeSpan daysUntilDueSpan = _dueDate - DateTime.Today;
        double daysUntilDue = daysUntilDueSpan.TotalDays;
        _rank = ( (_points * _pointsModifier) / daysUntilDue ) *_credits; //See equation.txt for how ranking works

        if (_rank < 0)
        {
            _rank = 9007199254740992 + _rank; //Manually underflow negative ranks
            _isOverdue = true;
        }

        if (daysUntilDue >= 30)
        {
            _rank -= 3;
        }
        else if (daysUntilDue >= 14)
        {
            _rank -= 1;
        }
    }

    public double GetRank()
    {
        return _rank;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public void OverrideModifier(int newModifier)
    {
        _pointsModifier = newModifier;
    }

    public int GetModifier()
    {
        return _pointsModifier;
    }

    public DateTime GetDueDate()
    {
        return _dueDate;
    }

    public double GetPoints()
    {
        return _points;
    }

    public int GetCredits()
    {
        return _credits;
    }

    public bool GetIsOverdue()
    {
        return _isOverdue;
    }
}