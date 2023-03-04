public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    private Random _random = new Random();

    public ReflectionActivity() : base("Reflection", "This activity will help you to reflect on times when you have shown strength and resilience. This can help you realize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void AddPrompts(params string[] prompts)
    {
        foreach (string prompt in prompts)
        {
            _prompts.Add(prompt);
        }
    }

    public void AddQuestions(params string[] questions)
    {
        foreach (string question in questions)
        {
            _questions.Add(question);
        }
    }

    private string GetPrompt()
    {
        int index = _random.Next(_prompts.Count());
        return _prompts[index];
    }

    private string GetQuestion()
    {
        int index = _random.Next(_questions.Count());
        return _questions[index];
    }

    private int ComputeQuestionDuration(int activityDuration)
    {
        if (activityDuration < 10)
        {
            return activityDuration;
        }

        if (activityDuration < 20)
        {
            return activityDuration / 2;
        }

        if (activityDuration < 30)
        {
            return activityDuration / 3;
        }

        return 10;
    }

    public override int DoActivity()
    {
        int duration = base.DoActivity();
        string prompt = GetPrompt();
        int questionDuration = ComputeQuestionDuration(duration);
        int numberOfQuestions = duration / questionDuration;

        Console.Clear();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("Press Enter when you have something in mind.");
        Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Starting in 3...");
        Console.Clear();
        Console.WriteLine("Starting in 2...");
        Console.Clear();
        Console.WriteLine("Starting in 1...");
        Console.Clear();

        Console.Clear();
        for (int i = 0; i < numberOfQuestions; i++)
        {
            Console.Write($"{GetQuestion()} ");
            for (int j = 0; j < questionDuration; j++)
            {
                base.LoadingAnimation();
            }
            Console.WriteLine();
        }

        base.EndMessage(duration);

        return 0; //This return value is unimportant and is only here to satisfy the override constraints
    }
}