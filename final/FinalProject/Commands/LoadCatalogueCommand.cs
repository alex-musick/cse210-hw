public class LoadCatalogueCommand
{
    Catalogue _catalogue = new Catalogue();

    public LoadCatalogueCommand(Catalogue catalogue)
    {
        _catalogue = catalogue;
    }
    public Catalogue Execute()
    {
        string[] lines = File.ReadAllLines("user_data.cat");
        bool isCourseString = false;
        Course course = new Course("dummy", 0);
        for (int i = 0; i < lines.Count(); i++)
        {
            string line = lines[i];
            if (line[0] == '+')
            {
                string[] attribs = line.Split("|");
                string name = attribs[0].Substring(1);
                int credits = int.Parse(attribs[1]);
                course = new Course(name, credits);
                continue;
            }
            else
            {
                string[] attribs = line.Split("|");
                string name = attribs[0].Substring(1);
                double points = double.Parse(attribs[1]);
                int credits = int.Parse(attribs[2]);
                DateTime dueDate = DateTime.Parse(attribs[3]);
                string type = attribs[4];


                Assignment assignment;
                switch (type)
                {
                    case("file"):
                    {
                        assignment = new FileAssignment(name, points, credits, dueDate);
                        break;
                    }
                    case("quiz"):
                    {
                        assignment = new QuizAssignment(name, points, credits, dueDate);
                        break;
                    }
                    case("text"):
                    {
                        assignment = new TextAssignment(name, points, credits, dueDate);
                        break;
                    }
                    case("generic"):
                    {
                        assignment = new GenericAssignment(name, points, credits, dueDate);
                        break;
                    }
                    default:
                    {
                        throw new Exception("Tried to load assignment with invalid type.");
                        break;
                    }
                }
                course.AddAssignment(assignment);
                try
                {
                    if (lines[i + 1][0] == '+')
                    {
                        _catalogue.AddCourse(course);
                    }
                }
                catch
                {
                    _catalogue.AddCourse(course);
                }
            }
        }

        return _catalogue;

    }

}