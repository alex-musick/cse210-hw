public class SaveCatalogueCommand : Command
{
    Catalogue _catalogue = new Catalogue();

    public SaveCatalogueCommand(Catalogue catalogue)
    {
        _catalogue = catalogue;
    }
    public override void Execute()
    {
        using (StreamWriter file = new StreamWriter("user_data.cat"))
        {
            foreach (string line in _catalogue.ToStrings())
            {
                file.WriteLine(line);
            }
        }
    }

}