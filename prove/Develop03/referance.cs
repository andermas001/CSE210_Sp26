class Reference
{
    private string _bookName;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string name, int chapter, int verse)
    {
        _bookName = name;
        _chapter = chapter;
        _verse  = verse;
        _endVerse = verse;
    }

    public Reference(string name, int chapter, int startverse, int endVerse)
    {
        _bookName = name;
        _chapter = chapter;
        _verse = startverse;
        _endVerse  = endVerse;
    }

    public void ShowReference()
    {
        if (_verse == _endVerse)
            {
                Console.WriteLine($"{_bookName} {_chapter}:{_verse}");
            }
        Console.WriteLine($"{_bookName} {_chapter}:{_verse}-{_endVerse}");
    }
    

    public string GetScriptureReference()
    {
        if (_verse == _endVerse)
            {
                return $"{_bookName} {_chapter}:{_verse}";
            }
            return $"{_bookName} {_chapter}:{_verse}-{_endVerse}";
    }

    private string GetScriptureReferenceString()
    {
        if (_verse == _endVerse)
            {
                return $"{_bookName} {_chapter}:{_verse}";
            }
            return $"{_bookName} {_chapter}:{_verse}-{_endVerse}";
    }
}