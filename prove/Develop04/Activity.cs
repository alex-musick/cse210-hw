public class Activity
{
    private string _name = "";
    private string _description = "";

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected void LoadingAnimation()
    {
        Console.Write("|");
        Thread.Sleep(125);
        Console.Write("\b \b");
        
        Console.Write("/");
        Thread.Sleep(125);
        Console.Write("\b \b");
        
        Console.Write("‒"); //This is an emdash, not a hyphen
        Thread.Sleep(125);
        Console.Write("\b \b");
        
        Console.Write("\\");
        Thread.Sleep(125);
        Console.Write("\b \b");

        Console.Write("|");
        Thread.Sleep(125);
        Console.Write("\b \b");
        
        Console.Write("/");
        Thread.Sleep(125);
        Console.Write("\b \b");
        
        Console.Write("‒");
        Thread.Sleep(125);
        Console.Write("\b \b");
        
        Console.Write("\\");
        Thread.Sleep(125);
        Console.Write("\b \b");
    }

    public virtual int DoActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} activity!");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        return GetActivityDuration();
    }

    protected void EndMessage(int duration)
    {
        Console.WriteLine();
        Console.WriteLine($"You've completed another {duration} seconds of the {_name} activity!");
        Console.Write("Good job!");
        LoadingAnimation();
        LoadingAnimation();
        LoadingAnimation();
    }

    private int GetActivityDuration()
    {
        bool secondsAreSet = false;
        int activityDuration = 0;
        int minimum = 5;


        while (!secondsAreSet)
        {
            Console.WriteLine($"How long, in seconds, would you like this activity to last? (minimum {minimum})");
            Console.WriteLine();
            Console.Write(">");
            string activityDurationString = Console.ReadLine();
            try
            {
                activityDuration = int.Parse(activityDurationString);
                secondsAreSet = true;
            }
            catch
            {
                Console.WriteLine("That's not a valid number of seconds.");
            }

            if (activityDuration < minimum)
            {
                secondsAreSet = false;
                Console.WriteLine($"You can not choose a duration lower than {minimum} seconds.");
            }
        }

        return activityDuration;        
    }
}