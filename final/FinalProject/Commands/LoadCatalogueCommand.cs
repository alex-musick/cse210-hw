public class LoadCatalogueCommand : Command
{
    Catalogue _catalogue = new Catalogue();

    public LoadCatalogueCommand(Catalogue catalogue)
    {
        _catalogue = catalogue;
    }
    public override void Execute()
    {
        _catalogue = BinarySerialization.ReadFromBinaryFile<Catalogue>("user_data.bin");
    }

}