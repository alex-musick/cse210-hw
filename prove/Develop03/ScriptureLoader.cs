public class ScriptureLoader
{
    private string[] _bibleFiles = System.IO.Directory.GetFiles("./scriptures/bible");
    private string[] _bomFiles = System.IO.Directory.GetFiles("./scriptures/bom");
    private string[] _dncFiles = System.IO.Directory.GetFiles("./scriptures/dnc");
    private string[] _pofgpFiles = System.IO.Directory.GetFiles("./scriptures/pofgp");
    private string[] _allFiles = new string[0];


    private Random random = new Random();


    public ScriptureLoader()
    {
        _allFiles = _allFiles.Concat(_bibleFiles).ToArray();
        _allFiles = _allFiles.Concat(_bomFiles).ToArray();
        _allFiles = _allFiles.Concat(_dncFiles).ToArray();
        _allFiles = _allFiles.Concat(_pofgpFiles).ToArray();
    }


    private string GetVerse(string[] book)
    {
        string line = "";
        int randomIndex = random.Next(book.Count());
        string file = book[randomIndex];
        string[] verses = System.IO.File.ReadAllLines(file);
        while (line == "")
        {
            randomIndex = random.Next(verses.Count());
            line = verses[randomIndex];
            line = line.Trim();
        }
        return line;
    }

    public List<string> GetScriptureByReference(string book, string volume, string chapterNumber, string verseNumber)
    {
        volume = volume.Trim().ToLower();

        if (book == "dnc") // This is a special case, separate from the rest, because d&c is stored across just a few files with titles formatted differently than the others
        {
            List<string> verses = new List<string>();
            foreach (string file in _dncFiles)
            {
                string[] fileLines = System.IO.File.ReadAllLines(file);
                foreach (string line in fileLines)
                {
                    verses.Add(line);
                }
            }

            string dncReference = $"{chapterNumber}:{verseNumber}";

            foreach (string line in verses)
            {
                string[] words = line.Split();
                if (words.Count() < 2) // Required to avoid index out of range errors for the blank lines in the file
                {
                    continue;
                }
                if (words[1] == dncReference)
                {
                    string returnedReference = words[0] + " " + words[1];
                    string returnedVerse = "";

                    for (int wordNumber = 2; wordNumber < words.Count(); wordNumber++)
                    {
                        returnedVerse += words[wordNumber] + " ";
                    }
                    returnedVerse = returnedVerse.Trim();

                    List<string> returnList = new List<string>();
                    returnList.Add(dncReference);
                    returnList.Add(returnedVerse);
                    return returnList;
                }
            }
        }

        string[] bookFiles = new string[0];
        switch(book)
        {
            case "bible":
            {
                bookFiles = _bibleFiles;
                break;
            }
            case "bom":
            {
                bookFiles = _bomFiles;
                break;
            }
            case "dnc":
            {
                bookFiles = _dncFiles;
                break;
            }
            case "pofgp":
            {
                bookFiles = _pofgpFiles;
                break;
            }
        }

        List<string> trimmedBookFiles = new List<string>();
        string[] splitBookFileEntry = new string[0];
        for (int index = 0; index < bookFiles.Count(); index++)
        {
            splitBookFileEntry = bookFiles[index].Split("/");
            int fileNameLength = splitBookFileEntry[3].Length;
            trimmedBookFiles.Add(splitBookFileEntry[3].Substring(3, fileNameLength - 3)); //This mess of hardcoded numbers returns the name of just the file, without the path, and with the leading numbers and "." stripped off



        }


        if (!trimmedBookFiles.Contains(volume))
        {
            return new List<string>();
        }

        int fileNameIndex = trimmedBookFiles.IndexOf(volume);
        if (fileNameIndex == -1) //Sanity check, this should never actually happen after the check above
        {
            return new List<string>();
        }

        string reference = $"{chapterNumber}:{verseNumber}";

        string[] volumeContents = System.IO.File.ReadAllLines(bookFiles[fileNameIndex]);
        foreach (string line in volumeContents)
        {
            string[] words = line.Split();
            if (words.Count() < 2) // Required to avoid index out of range errors for the blank lines in the file
            {
                continue;
            }
            if (words[1] == reference)
            {
                string returnedReference = words[0] + " " + words[1];
                string returnedVerse = "";

                for (int wordNumber = 2; wordNumber < words.Count(); wordNumber++)
                {
                    returnedVerse += words[wordNumber] + " ";
                }
                returnedVerse = returnedVerse.Trim();
                
                List<string> returnedList = new List<string>();
                returnedList.Add(returnedReference);
                returnedList.Add(returnedVerse);
                return returnedList;


            }
        }
        return new List<string>();



    }



    public List<string> GetScripture(string book = "any")
    {
        book = book.ToLower().Trim();
        string line = "";
        switch(book)
        {
            case("bible"):
            {
                line = GetVerse(_bibleFiles);
                break;
            }
            case("bom"):
            {
                line = GetVerse(_bomFiles);
                break;
            }
            case("dnc"):
            {
                line = GetVerse(_dncFiles);
                break;
            }
            case("pofgp"):
            {
                line = GetVerse(_pofgpFiles);
                break;
            }
            case("any"):
            {
                line = GetVerse(_allFiles);
                break;
            }
            default:
            {
                return new List<string>();
            }
        }
        string[] lineWords = line.Split();
        string reference = lineWords[0] + " " + lineWords[1];
        string verse = "";

        for (int wordNumber = 2; wordNumber < lineWords.Count(); wordNumber++)
        {
            verse += lineWords[wordNumber] + " ";
        }
        verse = verse.Trim();

        List<string> returnList = new List<string>();
        returnList.Add(reference);
        returnList.Add(verse);

        return returnList;

    }
}