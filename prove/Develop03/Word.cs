class Word
{
    private string _word;
    private bool _hidden;
    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public void Hide()
    {
        _hidden =  true;
    }

    public string GetText()
    {
        if (_hidden == true)
        {
            return new string ('_', _word.Length);
        }
        return _word;
    }

    public string GetHidden()
    {
        return new string('_', _word.Length);
    }
}