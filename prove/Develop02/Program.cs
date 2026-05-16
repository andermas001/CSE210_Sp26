using System;
using System.IO;
using System.IO.Enumeration;

class Program
{
    static void Main(string[] args)
    {
        int userSelection; 
        string fileName;
        string userFile;
        Menu myMenu = new Menu();
        Journal myJournal = new Journal();

        do {
        userSelection = myMenu.DisplayMenu();
        if (userSelection == 1)
            {
                JournalEntry myJournalEntry = new JournalEntry();
                myJournalEntry.CreateJournalEntry();
                myJournal.AddJournalEntry(myJournalEntry);
            }
        else if (userSelection == 2)
            {
                myJournal.DisplayJournal();
            }
        else if (userSelection == 3)
            {
                Console.WriteLine("Please enter the file you wish to load");
                userFile = Console.ReadLine();
                myJournal.LoadJournal(userFile);
            }
        else if (userSelection == 4)
            {
                Console.WriteLine("What is the file name?");
                fileName = Console.ReadLine();
                myJournal.SaveJournal(fileName);
                Console.WriteLine("Journal saved successfully!");
            }
        else if (userSelection == 5)
            {
                Console.WriteLine("Have a nice day Please come again");
                break;
            }
        else
            {
                Console.WriteLine($"Your input is invalid please try again");
            }

        }
        while ( userSelection < 6 && userSelection > 0);

    }
}