public class PromptGenerator{
    public List<string> _prompts = new List<string>();


    public string randomPrompt()
    {
        Random promptRandom = new Random();
        int index = promptRandom.Next(_prompts.Count);
        return _prompts[index];
    }

    public void loadPrompts(string fileName)
    {
        string[] fileContent = System.IO.File.ReadAllLines(fileName);
        foreach (string prompt in fileContent)
        {
            _prompts.Add(prompt);
        }
    }
}