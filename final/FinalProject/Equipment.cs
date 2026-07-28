public class Equipment : Item
{
    public double BonusStrength { get; }
    public double BonusDefense { get; }
    public Equipment(string name, string description, ItemType type, double bonusStrength, double bonusDefense, int value) 
        : base(name, description, type, value)
    {
        BonusStrength = bonusStrength;
        BonusDefense = bonusDefense;
    }
    public override void Use(Character user)
    {
        user.EquipItem(this);
    }
}