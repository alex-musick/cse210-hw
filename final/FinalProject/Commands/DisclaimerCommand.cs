public class DisclaimerCommand : Command
{
    public override void Execute()
    {
        Console.WriteLine("This program is not affiliated with Instructure/Canvas or any other relevant brands or subsidiaries.");
        Console.WriteLine("This program comes with NO WARRANTY and is not intended to replace any other homework management system.");
        Console.WriteLine("It is meant to be one tool to help the user organize their schoolwork.");
        Console.WriteLine("See DISCLIMAER.txt for more details.");
        Console.WriteLine();
        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
        Console.Clear();
    }
}