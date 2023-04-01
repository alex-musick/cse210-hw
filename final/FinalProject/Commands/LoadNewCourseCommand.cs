public class LoadNewCourseCommand : Command
{

    Catalogue _catalogue = new Catalogue();
    public LoadNewCourseCommand(Catalogue catalogue)
    {
        _catalogue = catalogue;
    }

    public override void Execute()
    {
        Console.WriteLine("Please type the path to course-data.js.");
        Console.WriteLine("If you don't know how to get this file, see the 'help' menu.");
        Console.Write(">");

        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("The file does not exist.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("How many credits is this course worth?");
        Console.Write(">");
        string creditsString = Console.ReadLine();
        int credits = 0;
        try
        {
            credits = int.Parse(creditsString);
            if (credits <= 0)
            {
                Console.WriteLine("That's not a valid number of credits.");
                return;
            }
        }
        catch
        {
            Console.WriteLine("That's not a valid number of credits.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("What would you like to call this course? (must not be blank)");
        Console.Write(">");
        string name = Console.ReadLine();
        if (name == "")
        {
            Console.WriteLine("That's not a valid course name.");
            return;
        }

        List<Assignment> assignments = new CourseParser().ParseFile(filePath, credits);
        if (assignments.Count() <= 0)
        {
            Console.WriteLine($"{filePath} is not a valid course-data file, or this course contains no rankable assignments.");
            return;
        }

        Course course = new Course(name, credits);
        foreach (Assignment assignment in assignments)
        {
            course.AddAssignment(assignment);
        }

        _catalogue.AddCourse(course);
    }
}