public class QuitCommand : Command
{
    public override void Execute()
    {
        Environment.Exit(0);
    }

}