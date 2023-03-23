public class InMemRepo : Repository
{

    private List<Goal> _goals = new List<Goal>();

    public override void Add(Goal goal)
    {
        if (!_goals.Contains(goal))
        {
            _goals.Add(goal);
        }
    }

    public override void Remove(Goal goal)
    {
        if (_goals.Contains(goal))
        {
            _goals.Remove(goal);
        }
    }

    public override List<Goal> GetAll()
    {
        return _goals;
    }
}