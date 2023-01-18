using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning02 World!");
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Minisoft";
        job1._startYear = 1997;
        job1._endYear = 2005;

        Job job2 = new Job();
        job2._company = "Jamsung";
        job2._jobTitle = "Bean Supervisor";
        job2._startYear = 2006;
        job2._endYear = 2016;

        Resume resume = new Resume();
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume._name = "Sam Cook";
        resume.Display();
    }
}