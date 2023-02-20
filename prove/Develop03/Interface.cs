public class Interface
{
    private ScriptureLoader scriptureLoader = new ScriptureLoader();
    private Mask mask = new Mask();

    
    private void Review(List<string> line)
    {
        string reference = line[0];
        string verse = line[1];

        var response = ("", false);
        // Dummy values, not used or significant

        bool done = false;
        string userInput = "";
        while (!done)
        {
            Console.Clear();
            Console.WriteLine(reference);
            Console.WriteLine();
            Console.WriteLine(verse);
            Console.WriteLine();
            Console.WriteLine("Press Enter when ready to continue, or type 'quit' to go back.");
            userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                break;
            }

            response = mask.MaskText(verse);
            verse = response.Item1;
            done = response.Item2;

        }
        Console.Clear();
        Environment.Exit(0); //Ordinarily I would just have it return to the menu, but it's a specific requirement that the program terminates here
        return;
    }

    private List<string> SpecificReferencePrompt()
    {
        Console.Clear();
        string bookChoice = "";
        while (bookChoice != "1" & bookChoice != "2" & bookChoice != "3" & bookChoice != "4")
        {
            Console.WriteLine("Please choose a book of scripture:");
            Console.WriteLine("1) Bible");
            Console.WriteLine("2) Book of Mormon");
            Console.WriteLine("3) Doctrine & Covenants");
            Console.WriteLine("4) The Pearl of Great Price");
            Console.WriteLine();
            Console.Write(">");
            bookChoice = Console.ReadLine();

            if (bookChoice != "1" & bookChoice != "2" & bookChoice != "3" & bookChoice != "4")
            {
                 Console.Clear();
                 Console.WriteLine("That's not a valid option.");
                 Console.WriteLine();
            }
        }

        switch(bookChoice.ToLower())
        {
            case "1":
            {
                bookChoice = "bible";
                break;
            }
            case "2":
            {
                bookChoice = "bom";
                break;
            }
            case "3":
            {
                bookChoice = "dnc";
                break;
            }
            case "4" :
            {
                bookChoice = "pofgp";
                break;
            }
            default:
            {
                Console.WriteLine("(DEBUG) WARNING: Somehow progressed beyond custom reference book selection without a valid option.");
                Console.WriteLine("Continuing, but prompt will fail.");
                break;
            }
        }


        string volumeChoice = "";
        if (bookChoice == "dnc")
        {
            volumeChoice = "dnc";
        }

        if (volumeChoice != "dnc")
        {
            Console.WriteLine();
            Console.WriteLine("Please type the specific book's full name.");
            Console.WriteLine("Format numbered books as 'number-book'");
            Console.WriteLine("Examples of valid inputs:");
            Console.WriteLine("2-nephi");
            Console.WriteLine("alma");
            Console.WriteLine("1-corinthians");
            Console.WriteLine();
            Console.Write(">");
            volumeChoice = Console.ReadLine().ToLower();
        }

        Console.WriteLine();
        Console.WriteLine("Please type the chapter number.");
        Console.Write(">");
        string chapterNumber = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Please type the verse number.");
        Console.Write(">");
        string verseNumber = Console.ReadLine();

        List<string> scripture = scriptureLoader.GetScriptureByReference(bookChoice, volumeChoice, chapterNumber, verseNumber);
        return scripture;
    }
    
    public void Menu()
    {
        Console.WriteLine("Welcome to the scripture memorizer!");
        Console.WriteLine("Please choose a book of scripture:");
        Console.WriteLine();
        Console.WriteLine("1) Bible (King James Version)");
        Console.WriteLine("2) The Book of Mormon");
        Console.WriteLine("3) Doctrine & Covenants");
        Console.WriteLine("4) The Pearl of Great Price");
        Console.WriteLine("5) Random");
        Console.WriteLine("6) Use specific reference");
        Console.WriteLine("7) Exit");
        Console.WriteLine();
        Console.Write(">");
        string userChoice = Console.ReadLine();
        
        List<string> scripture = new List<string>();

        switch(userChoice)
        {
            case "1":
            {
                scripture = scriptureLoader.GetScripture("bible");
                Review(scripture);
                break;
            }
            case "2":
            {
                scripture = scriptureLoader.GetScripture("bom");
                Review(scripture);
                break;
            }
            case "3":
            {
                scripture = scriptureLoader.GetScripture("dnc");
                Review(scripture);
                break;
            }
            case "4":
            {
                scripture = scriptureLoader.GetScripture("pofgp");
                Review(scripture);
                break;
            }
            case "5":
            {
                scripture = scriptureLoader.GetScripture("any");
                Review(scripture);
                break;
            }
            case "6":
            {
                while (scripture.Count < 2)
                {
                    scripture = SpecificReferencePrompt();
                    if (scripture.Count < 2)
                    {
                        Console.WriteLine("Sorry, you provided an invalid reference.");
                        Console.WriteLine("Returning to menu.");
                        break;
                    }
                    else
                    {
                        Review(scripture);
                    }
                }
                break;
            }
            case "7":
            {
                Environment.Exit(0);
                break;
            }
            default:
            {
                Console.WriteLine("That's not a valid option.");
                break;
            }
        }
        return;

    }
}