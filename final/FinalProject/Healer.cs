class Healer : Hero
{
    protected override double _attackPower => (_mana / 8) + (_lvl * 2);
    protected int _healingPower => (_mana / 4) + (_lvl * 5);

    // string name, int maxHp, int speed, int defense, int stamina, int strength)
    public Healer(string name) : 
    base(name, maxHp: 110, speed:11, defense:5, stamina: 100, strength: 5, mana: 100)
    {
        
    }

    public override void LevelUp()
    {
        _lvl ++;
        _maxHealth += 15;
        _strength += 1;
        _stamina += 5;
        _speed += 2;
        _mana += 10;
        // _currentMana =_mana; 
        // fill mana on level up?
        // fill health on level up?
    }


    public override void TakeTurn()
    {
        
    }

    public override void Attack()
    {

    }

}