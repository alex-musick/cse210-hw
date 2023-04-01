using System.Text.RegularExpressions;

public class CourseParser
{
    private List<Assignment> _assignments = new List<Assignment>();

    private string FindKeyData(string[] assignmentAttributes, string key)
    {
        Regex regex = new Regex(":(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"); //This hideous mess will split on colons, but ignore colons inside quotes
        key = $"\"{key}\"";
        for (int i = 0; i < assignmentAttributes.Count(); i++)
        {
            string[] pair = regex.Split(assignmentAttributes[i]);
            if (pair[0] == key)
            {
                return pair[1].Replace("\"", "");
            }
        }
        return "";
    }

    public List<Assignment> ParseFile(string fileName, int credits) //This is a long method. I think that's justified because none of this code will run on its own in other contexts, and splitting it into smaller methods would serve no practical purpose besides reducing readability for the sake of having more small private methods.
    {
        List<Assignment> finalList = new List<Assignment>();

        string rawCourseData = File.ReadAllLines(fileName)[0];
        string[] assignmentsData = rawCourseData.Split(new string[] {"\"id\":"}, StringSplitOptions.None);
        for (int i = 0; i < assignmentsData.Count(); i++)
        {
            assignmentsData[i] = assignmentsData[i].Replace("\\", "");
        }

        foreach (string item in assignmentsData)
        {
            string[] assignmentAttributes = item.Split(",");

            string name = FindKeyData(assignmentAttributes, "title").Trim();

            // Check if the assignment is actually a copyright string

            if (name.Contains("Copyright") & name.Contains("Source") & name.Contains("Info"))
            {
                continue;
            }

            //Exclude assingments that are completed, typeless or wiki pages, or are worth 0 points

            if (FindKeyData(assignmentAttributes, "completed") == "true")
            {
                continue;
            }

            string type = FindKeyData(assignmentAttributes, "type");
            if (type == "" | type == "WikiPage")
            {
                continue;
            }

            if (FindKeyData(assignmentAttributes, "submissionTypes") == "a file upload")
            {
                type = "File";
            }
            if (FindKeyData(assignmentAttributes, "submissionTypes") == "a text entry box")
            {
                type = "Text";
            }

            // Convert the date string to an actual datetime object

            string dueDateString = FindKeyData(assignmentAttributes, "dueAt");
            if (dueDateString == "")
            {
                continue;
            }
            int dueYear = int.Parse(dueDateString.Split("-")[0]);
            int dueMonth = int.Parse(dueDateString.Split("-")[1]);
            int dueDay = int.Parse(dueDateString.Split("-")[2].Substring(0, 2));
            DateTime dueDate = new DateTime(dueYear, dueMonth, dueDay);

            double points = 0;
            try
            {
                points = double.Parse(FindKeyData(assignmentAttributes, "pointsPossible"));
            }
            catch
            {
                continue;
            }
            if (points == 0)
            {
                continue;
            }

            // Bring it all together

            Assignment newAssignment;
            switch(type)
            {
                case ("Quizzes::Quiz"):
                {
                    newAssignment = new QuizAssignment(name, points, credits, dueDate);
                    finalList.Add(newAssignment);
                    break;
                }
                case ("File"):
                {
                    newAssignment = new FileAssignment(name, points, credits, dueDate);
                    finalList.Add(newAssignment);
                    break;
                }
                case ("Text"):
                {
                    newAssignment = new TextAssignment(name, points, credits, dueDate);
                    finalList.Add(newAssignment);
                    break;
                }
                default:
                {
                    newAssignment = new GenericAssignment(name, points, credits, dueDate);
                    finalList.Add(newAssignment);
                    break;
                }
            }

        }

        return finalList;
    }
}