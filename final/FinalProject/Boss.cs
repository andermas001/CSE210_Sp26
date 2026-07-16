class Boss : Monster
{
    public Boss(string name, int level) :  base(name, 
    maxHp: 350 +(level*75), 
    speed: 10 + (level * 2),
    defense: 10 + (level * 4) , 
    stamina: 50 + (level * 10), 
    strength: 25 + (level * 5),
    mana: 10,
    level:level
    )
    {
        _xpReward = 200 + (level * 50);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        // Golems blindly target whoever has the highest max health (usually the Tank)
        Character target = enemies.Where(h => h.IsAlive).OrderByDescending(h => h._maxHealth ).FirstOrDefault();
        
        if (target != null)
        {
            Console.WriteLine($"\n🪨 {_name} slowly winds up a massive smash at {target._name}!");
            double rawDamage = _strength;
            target.TakeDamage(rawDamage);
        }
    }
}