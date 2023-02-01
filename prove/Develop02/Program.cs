using System;

// To exceed the requirements, I load the prompts from a txt file, and allow the user to load their own prompts.
// This is useful because it means that the user can add new prompts to the program without having to re-compile it,
// increasing the useful lifespan of the program indefinitely.
class Program
{
    static void Main(string[] args)    
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        
        string defaultPromptsFile = "defaultprompts.txt";
        try
        {
            promptGenerator.loadPrompts(defaultPromptsFile);
        }
        catch
        {
            Console.WriteLine("defaultprompts.txt file is missing. Please replace it and try again.");
            Environment.Exit(0);
        
        }

        Validator validator = new Validator();
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

                // Cases 3, 4, and 5 need to be enclosed in blocks so that they can all use "string fileName" without conflicting. No such restriction exists for the other cases.

                case "3":
                {
                    Console.Write("Type the name of the journal file to load (not including \".journal\")>");
                    string fileName = Console.ReadLine();
                    if (validator.checkLoadFileName($"{fileName}.journal") == false)
                    {
                        Console.Clear();
                        Console.WriteLine("File does not exist.");
                        break;
                    }
                    Journal temporaryJournal = scribe.load(fileName, activeJournal);
                    if (activeJournal == temporaryJournal)
                    {
                        Console.Clear();
                        Console.WriteLine("Not a valid journal file.");
                        break;
                    }
                    else
                    {
                        activeJournal = temporaryJournal;
                        Console.Clear();
                        Console.WriteLine("Journal loaded!");
                        break;
                    }
                }
                
                case "4":
                {
                    Console.Write("Type the file name to save the journal to (will be overwritten, load first if you want to append)>");
                    string fileName = Console.ReadLine();
                    if (validator.checkSaveFileName(fileName) == false)
                    {
                        Console.Clear();
                        Console.WriteLine("File name is invalid.");
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Journal saved!");
                    scribe.save(activeJournal, fileName);
                    break;
                }
                
                case "5":
                {
                    Console.Write("Type the name of the file to load prompts from (including extension, e.g. \"prompts.txt\")>");
                    string fileName = Console.ReadLine();
                    if (System.IO.File.Exists(fileName))
                    {
                        promptGenerator = new PromptGenerator();
                        promptGenerator.loadPrompts(fileName);
                        if (promptGenerator._prompts.Count <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("File is empty!");
                            promptGenerator.loadPrompts(defaultPromptsFile);
                            break;
                        }
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The file does not exist.");
                        break;
                    }
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