class Reference
{
    private string _referance;
    private string _scripture;

    public Reference(string referance, string scripture)
    {
        _referance = referance;
        _scripture = scripture;
    }

    public Reference()
    {
        _referance = "";
        _scripture = "";
    }

    public void SetReference(string referance)
    {
        _referance = referance;
    }

    public void SetScripture(string scripture)
    {
        _scripture = scripture;
    }
}