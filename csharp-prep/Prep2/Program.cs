using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradeInput = Console.ReadLine();
        int gradePercent = int.Parse(gradeInput);

        string gradeLetter;
        if (gradePercent >= 90)
        {
            gradeLetter = "A";
        }
        else if (gradePercent >= 80)
        {
            gradeLetter = "B";
        }
        else if (gradePercent >= 70)
        {
            gradeLetter = "C";
        }
        else if (gradePercent >= 60)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }

        string gradeSign;
        if (gradePercent % 10 >= 7 && gradeLetter != "A" && gradeLetter != "F")
        {
            gradeSign = "+";
        }
        else if (gradePercent % 10 < 3 && gradeLetter != "F")
        {
            gradeSign = "-";
        }
        else
        {
            gradeSign = "";
        }
        
        Console.WriteLine($"Your grade letter for this course is {gradeLetter}{gradeSign}.");

        if (gradeLetter == "D" || gradeLetter == "F")
        {
            Console.WriteLine("You did not meet the requirements to pass this course, but hopefully it will be easier next time!");
        }
        else
        {
            Console.WriteLine("Good job, you passed!");
        }
    }
}