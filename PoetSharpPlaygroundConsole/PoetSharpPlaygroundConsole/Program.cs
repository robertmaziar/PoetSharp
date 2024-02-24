using NHyphenator;
using NHyphenator.Loaders;

class Program
{
    static void Main()
    {
        // Load CMU Pronouncing Dictionary
        Dictionary<string, string> cmuDictionary = LoadCMUDictionary("C://Users//rober//Desktop//cmudict.txt");

        // Word to look up
        //string word = "syllables";
        string word = "different";

        // Hyphenate the word
        string hyphenatedWord = HyphenateWord(word);


        // Look up stress information
        if (cmuDictionary.ContainsKey(word.ToUpper()))
        {
            string pronunciation = cmuDictionary[word.ToUpper()];
            int stressIndex = GetStressIndex(pronunciation);
            hyphenatedWord = PrefixStressedSyllable(hyphenatedWord, stressIndex);


            string temp = word.Substring(0, stressIndex);
        }

        Console.WriteLine($"Hyphenated word with stressed syllable marked: {hyphenatedWord}");
    }

    static Dictionary<string, string> LoadCMUDictionary(string filePath)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!line.StartsWith(";;;"))
                {
                    string[] parts = line.Split(new char[] { ' ' }, 2);
                    string word = parts[0];
                    string pronunciation = parts[1];
                    dictionary[word] = pronunciation;
                }
            }
        }
        return dictionary;
    }

    static int GetStressIndex(string pronunciation)
    {
        // Example: "S IH1 L AH0 B AH0 L Z" (1-based index)
        string[] phonemes = pronunciation.Split(' ');
        for (int i = 0; i < phonemes.Length; i++)
        {
            if (phonemes[i].EndsWith("1") || phonemes[i].EndsWith("2"))
            {
                return i + 1; // Stress index is 1-based
            }
        }
        return -1; // No stress marker found
    }

    static string HyphenateWord(string word)
    {
        var loader = new ResourceHyphenatePatternsLoader(HyphenatePatternsLanguage.EnglishUs);
        Hyphenator hypenator = new Hyphenator(loader, "-");
        var result = hypenator.HyphenateText(word);

        return result;
    }

    static string PrefixStressedSyllable(string word, int stressIndex)
    {
        if (stressIndex != -1)
        {
            // Find the index of the stressed syllable
            int currentIndex = 0;
            for (int i = 0; i < stressIndex - 1; i++)
            {
                currentIndex = word.IndexOf('-', currentIndex) + 1;
            }
            // Insert ` character before the stressed syllable
            word = word.Insert(currentIndex, "`");
        }
        return word;
    }
}
