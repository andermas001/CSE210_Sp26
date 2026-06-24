class Police : Person
{
    private string _weapon;
    private string _badgeNumber;

    public Police(string weapon, string badgeNumber, string firstName,
    string lastName, int age, float weight)
    : base(firstName, lastName, age, weight)
    {
        _weapon = weapon;
        _badgeNumber = badgeNumber;
    }

    public override string GetPersonInformation()
    {
        return ($"weapon: {_weapon}, Badge: {_badgeNumber},{GetPersonInformation()}");
    }

    public override double GetSalary()
    {
        return 100000;
    }
}