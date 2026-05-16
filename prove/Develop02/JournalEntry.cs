class JournalEntry
{
    string _date;

    string _prompt;

    string _response;

    string[] _prompts =
    //add more prompts
    {
        "How are you feeling today",
        "Who did you talk with today",
        "What did you like about today",
        "Did you eat any good food today"
    };

     public string GetRandomPrompt()
    {
        int index = Random.Shared.Next(_prompts.Length);
        return _prompts[index];
    }

    public void CreateJournalEntry()
    {
        _date = DateTime.Now.ToShortDateString();
        _prompt = GetRandomPrompt();
        Console.WriteLine(_prompt);
        _response = Console.ReadLine();

    }

    public void DisplayJournalEntry()
    {
        Console.WriteLine($"{_date}, {_prompt}, {_response}");
    }

    public string CreateFileSystemString()
    {
        string systemString = _date + "#" + _prompt + "#" + _response;
        return systemString;
    }

}