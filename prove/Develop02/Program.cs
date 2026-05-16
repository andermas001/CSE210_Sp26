using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");

        JournalEntry myJournalEntry = new JournalEntry();
        myJournalEntry.CreateJournalEntry();
        myJournalEntry.DisplayJournalEntry();
        
        Console.WriteLine(myJournalEntry.CreateFileSystemString());

        Journal myJournal = new Journal();
        myJournal.AddJournalEntry(myJournalEntry);

        myJournal.DisplayJournal();




    }
}