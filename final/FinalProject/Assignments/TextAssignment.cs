public class TextAssignment : Assignment
{
    public TextAssignment(string name, double points, int credits, DateTime dueDate) : base(name, points, credits, dueDate)
    {
        _type = "text";
        _pointsModifier = 2;
    }
}