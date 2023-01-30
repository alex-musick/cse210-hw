public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void newEntry(PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.randomPrompt();
        Console.WriteLine($"{prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry();
        newEntry._prompt = prompt;
        newEntry._response = response;
        
        DateTime currentTime = DateTime.Now;
        newEntry._date = currentTime.ToString();

        _entries.Add(newEntry);
    }

    public void displayEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.display();
            Console.WriteLine();
        }
    }
}