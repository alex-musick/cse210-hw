public class ExitCommand : Command
{

    public override void Execute()
    {
        Environment.Exit(0);
    }


}