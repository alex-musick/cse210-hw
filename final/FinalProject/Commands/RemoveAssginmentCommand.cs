public class RemoveAssignmentCommand : Command
{
    Catalogue _catalogue = new Catalogue();
    Course _course = new Course("dummy", 0);
    public RemoveAssignmentCommand(Catalogue catalogue)
    {
        _catalogue = catalogue;
    }

    public void SetCourse(Course course)
    {
        _course = course;
    }

    public override void Execute()
    {
        Course course = new CourseChooser().ChooseCourse(_catalogue);

        if (course.GetName() == "dummy" & course.GetCredits() == 0)
        {
            Console.WriteLine("That's not a valid course number.");
            return;
        }

        Catalogue singleCourseCatalogue = new Catalogue();
        singleCourseCatalogue.AddCourse(course);
        new ViewAssignmentsCommand(singleCourseCatalogue).Execute();

        Console.WriteLine();
        Console.Write("Please type the assignment number to remove: ");
        string assignmentNumberInput = Console.ReadLine();
        Assignment assignment;
        try
        {
            int assginmentNumber = int.Parse(assignmentNumberInput);
            assignment = course.GetAssignments()[assginmentNumber ];
        }
        catch
        {
            Console.WriteLine("That's not a valid assginment number");
            return;
        }

        Console.WriteLine($"Deleting assignment: {assignment.GetName()} from {course.GetName()}");
        Console.WriteLine("Input \"yes\" to confirm: ");
        string userDeleteConfirmation = Console.ReadLine();
        if (userDeleteConfirmation == "yes")
        {
            course.RemoveAssignment(assignment);
            Console.WriteLine("Assginment removed.");
        }
        else
        {
            Console.WriteLine("Course removal cancelled.");
        }
        return;
    }
}