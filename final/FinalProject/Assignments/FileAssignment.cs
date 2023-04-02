[Serializable]
public class FileAssignment : Assignment
{
    public FileAssignment(string name, double points, int credits, DateTime dueDate) : base(name, points, credits, dueDate)
    {
        _type = "file";
        _pointsModifier = 2;
    }
}