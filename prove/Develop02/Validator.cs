public class Validator
{
    public bool checkJournalFile (String[] journalFileContent)
    {
        return journalFileContent.Length % 3 == 0 & journalFileContent.Length != 0;
    }

    public bool checkLoadFileName (string fileName)
    {
        return fileName != "" & System.IO.File.Exists(fileName);
    }

    public bool checkSaveFileName (string fileName)
    {
        return fileName != "";
    }

}