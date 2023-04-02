public class ViewCourseCommand : Command
{
    Catalogue _catalogue = new Catalogue();
    public ViewCourseCommand(Catalogue catalogue)
    {
        _catalogue = catalogue;
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
        return;
    }

}