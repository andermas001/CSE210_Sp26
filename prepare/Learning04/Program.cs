using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment myAssignment = new Assignment("Tarzan", "Math");

        myAssignment.GetSummary();
        MathAssignment myMathAss = new MathAssignment("Mason Anderson", "Math", "7.2", "12-15");
        
        myMathAss.GetSummary();
        myMathAss.GetHomeworkList();

        WritingAssignment myWriteAss = new WritingAssignment("John Jones", "English", "Dark Literature");

        myWriteAss.GetSummary();
        myWriteAss.GetWritingInformation();
    }
}