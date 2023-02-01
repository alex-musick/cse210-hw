public class Scribe
{
    private Validator validator = new Validator();
    public void save (Journal journal, string fileName)
    {
        fileName = fileName + ".journal";

        using (StreamWriter writer = new System.IO.StreamWriter(fileName))
        {
            foreach (Entry entry in journal._entries)
            {
                writer.WriteLine(entry._date);
                writer.WriteLine(entry._prompt);
                writer.WriteLine(entry._response);
            }
        }
    }

    public Journal load (string fileName, Journal oldJournal)
    {
        fileName = fileName + ".journal";
        string[] fileContent = System.IO.File.ReadAllLines(fileName);

        if (validator.checkJournalFile(fileContent) == false)
        {
            return oldJournal;
        }

        Journal loadedJournal = new Journal();
        
        for (int lineCounter = 0; lineCounter != fileContent.Length; lineCounter += 3)
        {
            Entry newEntry = new Entry();
            newEntry._date = fileContent[lineCounter];
            newEntry._prompt = fileContent[lineCounter + 1];
            newEntry._response = fileContent[lineCounter + 2];
            loadedJournal._entries.Add(newEntry);
        }
        return loadedJournal;

    }
}