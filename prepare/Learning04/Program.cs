using System;

class Program
{
    static void Main(string[] args)
    {
        WritingAssignment test = new WritingAssignment("The life of Kermit", "Jim Henson", "Puppetry");
        Console.WriteLine(test.GetSummary());
        Console.WriteLine(test.GetWritingInformation());
    }
}