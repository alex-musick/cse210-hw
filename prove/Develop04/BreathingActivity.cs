public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you on your breathing. Follow the directions and try to focus entirely on your breathing. \nBreathing cycles take 15 seconds each, so the actual activity time may be slightly higher than the duration you specify.")
    {
    }

    private void BreathingAnimation(string character)
    {
        for (int i = 0; i < 8; i++)
        {
            Console.Write(character);
            Thread.Sleep(125);
        }

        
        for (int i = 0; i < 3; i++)
        {
        Console.Write(character);
        Thread.Sleep(250);
        }

        Console.Write(character);
        Thread.Sleep(500);

        Console.Write(character);
    }

    public override int DoActivity()
    {
        int duration = base.DoActivity();
        if (duration < 15)
        {
            duration = 15;
        }
        int durationMs = duration * 1000;
        int totalCycles = durationMs / 15000; //This is the duration in ms of one complete cycle
        duration = totalCycles * 15; // Replace the duration value with the actual number of seconds this activity will take so the end message is accurate.

        Console.WriteLine("Inhale when the bar grows, and exhale when the bar shrinks.");
        Console.Write("Get ready, starting in 5 seconds....");
        base.LoadingAnimation();
        base.LoadingAnimation();
        base.LoadingAnimation();
        base.LoadingAnimation();
        base.LoadingAnimation();


        for (int i = 0; i < totalCycles; i++)
        {
            Console.Clear();
            Console.WriteLine("Breath in...");
            BreathingAnimation("|");
            Thread.Sleep(5250);

            Console.Clear();
            Console.WriteLine("Breath out...");
            Console.Write("|||||||||||||");
            BreathingAnimation("\b \b");
            Thread.Sleep(5250);
        }

        base.EndMessage(duration);

        return 0; //This return value is unimportant and is only here to satisfy the override constraints
    }
}