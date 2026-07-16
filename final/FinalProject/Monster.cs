abstract class  Monster : Character
{
    protected int _xpReward;

    protected Monster(string name, int maxHp, double speed, double defense, int stamina, double strength, int mana, int level) 
    : base(name, maxHp, speed, defense, stamina, strength, mana)
    {
        Lvl = level;
    }

    public virtual int XpGiven() 
    {
        return _xpReward;
    }

}