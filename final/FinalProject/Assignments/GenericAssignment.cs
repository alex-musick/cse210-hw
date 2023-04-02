[Serializable]
public class GenericAssignment : Assignment
{
    public GenericAssignment(string name, double points, int credits, DateTime dueDate) : base(name, points, credits, dueDate)
    {
        _type = "generic";
        _pointsModifier = 3;
    }
}