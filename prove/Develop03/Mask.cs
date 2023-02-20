public class Mask
{

    private Random _random = new Random();
    public (string, bool) MaskText(string input)
    // Returns masked string, true if the input was already all underscores.
    {
        string[] words = input.Split(' ');
        List<int> usedIndexes = new List<int>();

        // These four values are used later on in this method, but it saves a lot of trouble if they're initialized now, outside of a block.
        int randomIndex = 0;
        int numberOfValidWords = 0;
        int wordLength = 0;
        string finalString = "";


        foreach (string word in words)
        {
            if (!word.Contains("_"))
            {
                numberOfValidWords++;
            }
        }

        if (numberOfValidWords == 0)
        {
            return (input, true);
        }
        else if (numberOfValidWords < 3)
        {
            for (int wordsCounter = 0; wordsCounter != words.Length; wordsCounter++)
            {
                if (!words[wordsCounter].Contains("_"))
                {
                    wordLength = words[wordsCounter].Length;
                    words[wordsCounter] = "";
                    for (int underscoreCounter = 0; underscoreCounter < wordLength; underscoreCounter++)
                        {
                            words[wordsCounter] += "_";
                        }
                }
            }
            finalString = "";
            foreach (string word in words)
            {
                finalString += $"{word} ";
            }
            finalString = finalString.Trim();
            return (finalString, false);
        }

        for (int counter = 0; counter < 3; counter++)
        {
            do
            {
                randomIndex = _random.Next(words.Length);
            } 
            while (usedIndexes.Contains(randomIndex) | words[randomIndex].Contains("_"));
            usedIndexes.Add(randomIndex);

            wordLength = words[randomIndex].Length;
            words[randomIndex] = "";
            for (int underscoreCounter = 0; underscoreCounter < wordLength; underscoreCounter++)
            {
                words[randomIndex] += "_";
            }
        }   

        finalString = "";
        foreach (string word in words)
        {
            finalString += $"{word} ";
        }
        finalString = finalString.Trim();
        return (finalString, false);

    }
}