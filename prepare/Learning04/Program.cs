using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment myAssignment = new Assignment("Tarzan", "Math");
       
        Console.WriteLine(myAssignment.GetSummary());
        MathAssignment myMathAss = new MathAssignment("Mason Anderson", "Math", "7.2", "12-15");
        
        Console.WriteLine(myMathAss.GetSummary());
        Console.WriteLine(myMathAss.GetHomeworkList());

        WritingAssignment myWriteAss = new WritingAssignment("John Jones", "English", "Dark Literature");

        Console.WriteLine(myWriteAss.GetSummary());
        Console.WriteLine(myWriteAss.GetWritingInformation());
    }
}