public class Course
{
    private int _credits = 0;
    private string _name = "";

    private List<Assignment> _assignments = new List<Assignment>();

    public Course(string name, int credits)
    {
        _name = name;
        _credits = credits;
    }

    public void AddAssignment(Assignment assignment)
    {
        if (!_assignments.Contains(assignment))
        {
            _assignments.Add(assignment);
        }
    }

    public void RemoveAssignment(Assignment assignment)
    {
        if (_assignments.Contains(assignment))
        {
            _assignments.Remove(assignment);
        }
    }

    public void RankAssignments()
    {
        foreach(Assignment assignment in _assignments)
        {
            assignment.Rank();
        }
    }

    public List<Assignment> GetAssignments()
    {
        return _assignments;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetCredits()
    {
        return _credits;
    }

}