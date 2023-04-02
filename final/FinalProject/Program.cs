using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Catalogue catalogue = new Catalogue();

        try
        {
            catalogue = BinarySerialization.ReadFromBinaryFile<Catalogue>("user_data.bin");
        }
        catch
        {
        }


        Dictionary<string, Command> commandsDict = new Dictionary<string, Command>();
        commandsDict["1"] = new ViewAssignmentsCommand(catalogue);
        commandsDict["2"] = new LoadNewCourseCommand(catalogue);
        commandsDict["3"] = new ViewCourseCommand(catalogue);
        commandsDict["4"] = new RemoveCourseCommand(catalogue);
        commandsDict["5"] = new AddAssignmentCommand(catalogue);
        commandsDict["6"] = new RemoveAssignmentCommand(catalogue);
        commandsDict["7"] = new SaveCatalogueCommand(catalogue);
        commandsDict["8"] = new HelpCommand();
        commandsDict["9"] = new QuitCommand();

        new DisclaimerCommand().Execute();

        while (true)
        {
            Console.WriteLine("1. View Assginments");
            Console.WriteLine("2. Import Course");
            Console.WriteLine("3. View Specific Course");
            Console.WriteLine("4. Remove Course");
            Console.WriteLine("5. Add Assignment Manually");
            Console.WriteLine("6. Remove Assignment");
            Console.WriteLine("7. Save");
            Console.WriteLine("8. Help");
            Console.WriteLine("9. Quit");
            Console.WriteLine();
            Console.Write(">");
            string menuChoice = Console.ReadLine();

            try
            {
                Console.Clear();
                commandsDict[menuChoice].Execute();
                Console.WriteLine();
                Console.Write("Press Enter to continue.");
                Console.ReadLine();
                Console.Clear();
            }
            catch
            {
                Console.WriteLine("That's not a valid menu option.");
                Console.WriteLine();
            }
        }
    }
}