class Monster : Character
{
    public virtual int XpReward () 
    {
        
        return 5;
    }

    public override void TakeTurn(Character Target)
    {
        throw new NotImplementedException();
    }

    public override void Attack(int damage)
    {
        throw new NotImplementedException();
    }

}