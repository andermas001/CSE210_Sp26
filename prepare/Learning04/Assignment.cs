class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }
    public Assignment()
    {
        _studentName = "";
        _topic = "";
    }
    
    public string GetSummary()
    {
        return ($"Name: {_studentName} topic: {_topic}");
    }
}