class Word
{
    private string _text;

    public Word(string text)
    {
        _text = text;
    }

    public string getText() => _text;

    public string GetHidden()
    {
        return new string('_', _text.Length);
    }
}