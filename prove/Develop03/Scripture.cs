class Scripture
{
    private List<Word> _words;

    private Reference _reference;

    public Scripture(string name, int chapter, int verse, string text)
    {
        
    }

    public Scripture(string name, int chapter, int startVerse, int endVerse, string text)
    {
        
    }

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word> {};

        string[] wordsSplit = text.Split(" ");
        foreach(string word in wordsSplit)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideSomeWords(int value)
    {
        Random random = new Random();

        for (int i = 0; i < value; i++)
        {
            List<Word> visibleWords = _words.Where( w => !w.IsHidden()).ToList();

            if (visibleWords.Count() == 0)
            {
                break;
            }

            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
        }
    }

    public void ShowScripture()
    {
        List<string> words = new List<string>();
        foreach (Word word in _words)
        {
            words.Add(word.GetText());
        }
        string fulltext = string.Join(" ", words);
        Console.WriteLine($"{_reference.GetScriptureReference()} - {fulltext}");
    }

    public string GetScriptureReference()
    {
        return "";
    }

    private int NumberOfHiddenWords()
    {
        return 5;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(i => i.IsHidden());
    }

    private List<Word> ConvertToWords(string text)
    {
        List<Word> words  = new List<Word> {};
        return words;
    }



    

}