public class Warrior : Hero
{
    /*
        level Scaling Hp: 20, speed: 1, defense: 2, strength: 3, stamina: 5
    */
    // string name, int maxHp, int speed, int defense, int stamina, int strength)

    public Warrior(string name) : 
    base(name, maxHp: 150, speed:10, defense:8, stamina: 100, strength: 25, mana: 10)
    {
        
    }

    public override void LevelUp()
    {
        _lvl ++;
        _maxHealth += 20;
        _defense += 2;
        _speed += 1;
        _strength += 5;
        _stamina += 5;
    }

    public override void TakeTurn()
    {
        /* Example: Strong Attack uses Stamina and scales off Strength
        Character target = enemies[0]; 
        int damage = _attackPower + 10; // 15 + 10 = 25 baseline damage at Level 1
        target.TakeDamage(damage);
        */
    }
    public override void Attack()
    {
        
    }
}