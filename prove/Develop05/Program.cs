using System;

class Program
{
    static void Main(string[] args)
    {
        InMemRepo repo = new InMemRepo();

        Dictionary<string, Command> commands = new Dictionary<string, Command>();
        commands["1"] = new NewGoalCommand(repo);
        commands["2"] = new ListGoalsCommand(repo);
        commands["3"] = new SaveGoalsCommand(repo);
        commands["4"] = new LoadGoalsCommand(repo);
        commands["5"] = new RecordEventCommand(repo);
        commands["6"] = new ExitCommand();

        while (true)
        {
            new PrintTotalPointsCommand(repo).Execute();
            Console.WriteLine();
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List all goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.WriteLine();

            Console.Write("Make your selection now: ");
            string userChoice = Console.ReadLine();
            Console.Clear();
            try
            {
                commands[userChoice].Execute();
            }
            catch
            {
                Console.WriteLine("That's not a valid option.");
                Console.WriteLine();
            }

        }
    }
}