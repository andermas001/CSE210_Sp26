class Mage : Hero
{
    protected override double _attackPower => (_mana / 4) + (_lvl * 5);

    /*
        level Scaling Hp: 10, speed: 2, defense: 1, strength: 2, stamina: 5, mana 10
    */


    
     public Mage(string name) : base(name, maxHp: 100, speed:14, defense:3, stamina: 70, strength: 10, mana: 100)
    {
    }

    public override void LevelUp()
    {
        _lvl ++;
        _maxHealth += 10;
        _defense += 1;
        _speed += 2;
        _strength += 2;
        _stamina += 5;
        _mana += 10;
    }

    public override void TakeTurn()
    {
        
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }


}