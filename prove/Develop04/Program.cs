using System;

class Program
{
    static void Main(string[] args)
    {

        //I showed creativity by creating a unique animation for the breathing activity where a bar grows and shrinks to indicate how much air you should have.
        //It slows down when reading the end, both when growing and when shrinking.

        BreathingActivity breathingActivity = new BreathingActivity();
        
        ListingActivity listingActivity = new ListingActivity();
        listingActivity.AddQuestions("Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?", "What goals have you achieved this year?");

        ReflectionActivity reflectionActivity = new ReflectionActivity();
        reflectionActivity.AddPrompts("Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless.", "Think of a time when you made positive change in your life.");
        reflectionActivity.AddQuestions("Why was this experience meaningful to you?", "Had you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as succesful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?");

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Type the number of your selection now, and then press Enter: ");
            string userChoice = Console.ReadLine();


            Console.Clear();
            switch (userChoice)
            {
                case "1":
                {
                    breathingActivity.DoActivity();
                    break;
                }
                case "2":
                {
                    reflectionActivity.DoActivity();
                    break;
                }
                case "3":
                {
                    listingActivity.DoActivity();
                    break;
                }
                case "4":
                {
                    Environment.Exit(0);
                    break; //This line will never run, but is required in order to compile succesfully
                }
                default:
                {
                    Console.WriteLine("That's not a valid option.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    break;
                }
            }
        }

    }
}