public class HelpCommand : Command
{
    public override void Execute()
    {
        Console.WriteLine("To obtain a course-data.js file, do the following:");
        Console.WriteLine("1. Open the desired course on Canvas.");
        Console.WriteLine("2. Navigate to Modules.");
        Console.WriteLine("3. In the upper-right of the page, click \"Export Course Content.\"");
        Console.WriteLine("4. Wait for it to download a zip file.");
        Console.WriteLine("5. Extract the zip file.");
        Console.WriteLine("6. Open the course folder.");
        Console.WriteLine("7. Open the viewer folder.");
        Console.WriteLine("8. Here you will find the course-data.js file. Move it wherever you want.");
        Console.WriteLine();
        Console.WriteLine("When importing a course, make sure to type the full path to the file, including the file's name. Relative and absolute are both appropriate. For example:");
        Console.WriteLine("C:\\users\\bob\\desktop\\programming.js");
        Console.WriteLine("..\\desktop\\research-writing.js");
        Console.WriteLine("programming.js");
        Console.WriteLine("~/Downloads/course-data.js");
        Console.WriteLine();
        Console.WriteLine("You do not need to keep the course-data.js file after importing it.");
        Console.WriteLine();
    }
}