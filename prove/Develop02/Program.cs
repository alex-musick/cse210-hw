using System;

// To exceed the requirements, I load the prompts from a txt file, and allow the user to load their own prompts.
// This is useful because it means that the user can add new prompts to the program without having to re-compile it,
// increasing the useful lifespan of the program indefinitely.
class Program
{
    static void Main(string[] args)    
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        
        try
        {
            promptGenerator.loadPrompts("defaultprompts.txt");
        }
        catch
        {
            Console.WriteLine("defaultprompts.txt file is missing. Please replace it and try again.");
            Environment.Exit(0);
        
        }
        Journal activeJournal = new Journal();
        Scribe scribe = new Scribe();

        while (true)
        {
            
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following options.");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load Journal");
            Console.WriteLine("4. Save Journal");
            Console.WriteLine("5. Load Prompts");
            Console.WriteLine("6. Exit");

            Console.Write(">");
            string menuChoice = Console.ReadLine();

            switch(menuChoice)
            {
                case "1":
                    activeJournal.newEntry(promptGenerator);
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    activeJournal.displayEntries();
                    break;
                case "3":
                    Console.Write("Type the name of the journal file to load>");
                    try
                    {
                        activeJournal = scribe.load(Console.ReadLine());
                        Console.Clear();
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("The file does not exist.");
                    }
                    
                    break;
                case "4":
                    Console.Write("Type the file name to save the journal to>");
                    scribe.save(activeJournal, Console.ReadLine());
                    Console.Clear();
                    break;
                case "5":
                    Console.Write("Type the name of the file to load prompts from>");
                    string fileName = Console.ReadLine();
                    if (System.IO.File.Exists(fileName))
                    {
                        promptGenerator = new PromptGenerator();
                        promptGenerator.loadPrompts(fileName);
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The file does not exist.");
                        break;
                    }

                case "6":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("That's not a valid option.");
                    Console.Clear();
                    break;
            }

        }
    }
}