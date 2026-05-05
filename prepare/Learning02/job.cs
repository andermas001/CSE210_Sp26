public class Job
{
    public string _jobTitle;
    public double _jobIncome;
    public string _jobLocation;

    public string _jobCompany;

    public void DisplayJobDetails()
    {
        Console.WriteLine($"Job Title: {_jobTitle}, Job Company: {_jobCompany}");
    }

}