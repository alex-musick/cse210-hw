public class Repository
{
    public virtual void Add(Goal goal)
    {
        throw new Exception("Can't add goal to base Repo class");
    }

    public virtual void Remove(Goal goal)
    {
        throw new Exception("Can't remove goal from base Repo class");
    }

    public virtual List<Goal> GetAll()
    {
        throw new Exception("Can't get goals from base Repo class");
    }
}