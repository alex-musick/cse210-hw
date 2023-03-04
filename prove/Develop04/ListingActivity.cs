public class ListingActivity : Activity
{
    private List<string> _questions = new List<string>();
    private Random _random = new Random();

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void AddQuestions(params string[] questions)
    {
        foreach (string question in questions)
        {
            _questions.Add(question);
        }
    }

    private string GetQuestion()
    {
        int index = _random.Next(_questions.Count());
        return _questions[index];
    }

    public override int DoActivity()
    {
        int duration = base.DoActivity();

        Console.WriteLine();
        Console.WriteLine("Type as many responses as you can to the following prompt. Push Enter after each response.");
        Console.WriteLine();
        Console.WriteLine($"---{GetQuestion()}---");
        Console.Write("Get ready, starting in 5 seconds...");
        base.LoadingAnimation();
        base.LoadingAnimation();
        base.LoadingAnimation();
        base.LoadingAnimation();
        base.LoadingAnimation();

        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(duration);

        while (currentTime < endTime)
        {
            Console.WriteLine();
            Console.Write(">");
            Console.ReadLine();

            currentTime = DateTime.Now;
        }

        base.EndMessage(duration);
        return 0;
        
    }

}