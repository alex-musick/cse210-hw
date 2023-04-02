[Serializable]
public class Catalogue
{
    private List<Course> _courses = new List<Course>();

    public void AddCourse(Course course)
    {
        if (!_courses.Contains(course))
        {
            _courses.Add(course);
        }
    }

    public void RemoveCourse(Course course)
    {
        if(_courses.Contains(course))
        {
            _courses.Remove(course);
        }
    }

    public List<Course> GetAllCourses()
    {
        return _courses;
    }

    public List<Assignment> GetAllAssignments()
    {
        List<Assignment> returnedList = new List<Assignment>();
        foreach (Course course in _courses)
        {
            foreach (Assignment assignment in course.GetAssignments())
            {
                returnedList.Add(assignment);
            }
        }

        returnedList.Sort((x,y) => y.GetRank().CompareTo(x.GetRank())); // Sort list by assignment rank; ties will be handled when enumerating
        return returnedList;
    }

    public void RankAllAssignments()
    {
        foreach (Course course in _courses)
        {
            course.RankAssignments();
        }
    }
}