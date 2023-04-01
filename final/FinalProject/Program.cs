using System;

class Program
{
    static void Main(string[] args)
    {
        Catalogue testCat = new Catalogue();
        new LoadNewCourseCommand(testCat).Execute();

        testCat.RankAllAssignments();

        foreach (Assignment assignment in testCat.GetAllAssignments())
        {
            Console.WriteLine($"{assignment.GetName()}, {assignment.GetRank()}");
        }

        new ViewAssignmentsCommand(testCat).Execute();
    }
}