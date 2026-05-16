class Journal
{
    List<JournalEntry> _journalEntries = new List <JournalEntry> ();

    public void AddJournalEntry(JournalEntry journalEntry)
    {
        _journalEntries.Add(journalEntry);

    }

    public void DisplayJournal()
    {
        foreach (JournalEntry journalEntry in _journalEntries)
        {
            journalEntry.DisplayJournalEntry();
        }
    }

    public void SaveJournal(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (JournalEntry entry in _journalEntries)
            {
                outputFile.WriteLine(entry.CreateFileSystemString());
            }
        }
    }

    public void LoadJournal(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            JournalEntry entry = new JournalEntry();
            entry.LoadFromFileString(line);
            _journalEntries.Add(entry);
        }
    }

}