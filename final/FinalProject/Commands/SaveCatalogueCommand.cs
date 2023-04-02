public class SaveCatalogueCommand : Command
{
    Catalogue _catalogue = new Catalogue();

    public SaveCatalogueCommand(Catalogue catalogue)
    {
        _catalogue = catalogue;
    }
    public override void Execute()
    {
        BinarySerialization.WriteToBinaryFile<Catalogue>("user_data.bin", _catalogue);
    }

}