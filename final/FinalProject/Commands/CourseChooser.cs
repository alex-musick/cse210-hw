public class CourseChooser
{
    public Course ChooseCourse(Catalogue catalogue)
    {
        new ViewAllCoursesCommand(catalogue).Execute();
        Console.WriteLine();
        Console.Write("Please choose the course number you want to view: ");
        string courseNumberInput = Console.ReadLine();

        try
        {
            return catalogue.GetAllCourses()[int.Parse(courseNumberInput) - 1];
        }
        catch
        {
            return new Course("dummy", 0);
        }
    }
}