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

    public string getPoliceInformation()
    {
        return ($"weapon: {_weapon}, Badge: {_badgeNumber}, Name: {_fname} {_lName}, age: {age}, weight: {_weight}");
    }
}