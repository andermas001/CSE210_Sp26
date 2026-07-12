class Tank : Hero
{
    // string name, int maxHp, int speed, int defense, int stamina, int strength)
    public Tank(string name) : 
    base(name, maxHp: 220, speed:6, defense:14, stamina: 120, strength: 12, mana: 10)
    {
        
    }

    public override void LevelUp()
    {
        _lvl ++;
        _maxHealth += 35;
        _defense += 4;
        _speed += 1;
        _strength += 3;
        _stamina += 8;
    }

    public override void TakeTurn()
    {
        
    }

    public override void Attack()
    {
      
    }

}