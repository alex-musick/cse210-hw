public class RemoveCourseCommand : Command
{
    Catalogue _catalogue = new Catalogue();
    public RemoveCourseCommand(Catalogue catalogue)
    {
        _catalogue = catalogue;
    }

    public override void Execute()
    {
        new ViewAllCoursesCommand(_catalogue).Execute();
        Console.WriteLine();
        Console.Write("Please type the course number to remove: ");
        string courseNumberInput = Console.ReadLine();
        Course course = new Course("dummy", 0);

        try
        {
            course = _catalogue.GetAllCourses()[int.Parse(courseNumberInput) - 1];
        }
        catch
        {
            Console.WriteLine("That's not a valid course number.");
            return;
        }

        if (course.GetName() == "dummy" & course.GetCredits() == 0)
        {
            Console.WriteLine("That's not a valid course number.");
            return;
        }

        Console.WriteLine($"Deleting course: {course.GetName()}");
        Console.WriteLine("Input \"yes\" to confirm: ");
        string userDeleteConfirmation = Console.ReadLine();
        if (userDeleteConfirmation == "yes")
        {
            _catalogue.RemoveCourse(course);
            Console.WriteLine("Course removed.");
        }
        else
        {
            Console.WriteLine("Course removal cancelled.");
        }
    }
}