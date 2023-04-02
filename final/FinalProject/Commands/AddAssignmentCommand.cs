public class AddAssignmentCommand : Command
{
    Catalogue _catalogue = new Catalogue();
    Course _course = new Course("dummy", 0);
    public AddAssignmentCommand(Catalogue catalogue)
    {
        _catalogue = catalogue;
    }

    private void SetCourse()
    {
        _course = new CourseChooser().ChooseCourse(_catalogue);
    }

    public override void Execute()
    {
        SetCourse();

        int credits = _course.GetCredits();

        if (_course.GetName() == "dummy" & _course.GetCredits() == 0)
        {
            Console.WriteLine("That's not a valid course number.");
            return;
        }

        Console.Write("What is this assignment called?: ");
        string name = Console.ReadLine();
        if (name == "")
        {
            Console.WriteLine("That's not a valid assignment name.");
        }

        Console.Write("How many points is this assignment worth? (min 1): ");
        string pointsString = Console.ReadLine();
        double points = 0;
        try
        {
            points = double.Parse(pointsString);
        }
        catch
        {
            Console.WriteLine("That's not a valid number of points.");
            return;
        }
        if (points <= 0)
        {
            Console.WriteLine("That's not a valid number of points.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("When is the assignment due? (YYYY-MM-DD): ");
        string dueDateInput = Console.ReadLine();
        DateTime dueDate;
        try
        {
            dueDate = DateTime.Parse(dueDateInput);
        }
        catch
        {
            Console.WriteLine("That's not a valid due date.");
            return;
        }

        Console.WriteLine("What type of assignment is it?");
        Console.WriteLine("1. Quiz");
        Console.WriteLine("2. File Upload");
        Console.WriteLine("3. Text Box");
        Console.WriteLine("4. Other");
        Console.Write(">");
        string assignmentTypeSelection = Console.ReadLine();
        switch (assignmentTypeSelection)
        {
            case ("1"):
            {
                _course.AddAssignment(new QuizAssignment(name, points, credits, dueDate));
                break;
            }
            case ("2"):
            {
                _course.AddAssignment(new FileAssignment(name, points, credits, dueDate));
                break;
            }
            case ("3"):
            {
                _course.AddAssignment(new TextAssignment(name, points, credits, dueDate));
                break;
            }
            case ("4"):
            {
                _course.AddAssignment(new GenericAssignment(name, points, credits, dueDate));
                break;
            }
            default:
            {
                Console.WriteLine("That's not a valid assginment type.");
                break;
            }
        }
        return;
    }
}