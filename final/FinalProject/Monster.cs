abstract class  Monster : Character
{
    protected int _xpReward;

    protected Monster(string name, int maxHp, double speed, double defense, int stamina, double strength, int mana, int level) 
    : base(name, maxHp, speed, defense, stamina, strength, mana)
    {
        _lvl = level;
    }

    public virtual int XpGiven() 
    {
        return _xpReward;
    }

    public override void TakeTurn()
    {
    }

    public override void Attack()
    {
    }

}