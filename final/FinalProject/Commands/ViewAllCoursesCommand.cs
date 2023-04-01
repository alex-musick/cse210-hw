public class ViewAllCoursesCommand : Command
{
    Catalogue _catalogue = new Catalogue();
    public ViewAllCoursesCommand(Catalogue catalogue)
    {
        _catalogue = catalogue;
    }

    public override void Execute()
    {
        Console.WriteLine("Course | Credits");
        foreach (Course course in _catalogue.GetAllCourses())
        {
            Console.WriteLine($"1. {course.GetName()} | {course.GetCredits()}");
        }
    }
}