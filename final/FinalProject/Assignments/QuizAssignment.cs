[Serializable]
public class QuizAssignment : Assignment
{
    public QuizAssignment(string name, double points, int credits, DateTime dueDate) : base(name, points, credits, dueDate)
    {
        _type = "quiz";
        _pointsModifier = 1;
    }
}