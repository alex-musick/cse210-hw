public class ViewCourseCommand : Command
{
    Catalogue _catalogue = new Catalogue();
    public ViewCourseCommand(Catalogue catalogue)
    {
        _catalogue = catalogue;
    }

    public override void Execute()
    {
        Course course = ChooseCourse();
        if (course.GetName() == "dummy" & course.GetCredits() == 0)
        {
            Console.WriteLine("That's not a valid course number.");
            return;
        }
        Catalogue singleCourseCatalogue = new Catalogue();
        singleCourseCatalogue.AddCourse(course);
        new ViewAssignmentsCommand(singleCourseCatalogue).Execute();
        return;
    }

    private Course ChooseCourse()
    {
        new ViewAllCoursesCommand(_catalogue).Execute();
        Console.WriteLine();
        Console.Write("Please choose the course number you want to view: ");
        string courseNumberInput = Console.ReadLine();

        try
        {
            return _catalogue.GetAllCourses()[int.Parse(courseNumberInput)];
        }
        catch
        {
            return new Course("dummy", 0);
        }
    }
}