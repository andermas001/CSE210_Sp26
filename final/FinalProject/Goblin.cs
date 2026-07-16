class Goblin : Monster
{
    public Goblin(string name, int level) :  base(name, 
    maxHp: 30 +(level*10), 
    speed: 12 + (level *3),
    defense: 1 + level, 
    stamina: 50 + (level *5), 
    strength: 5 + (level *2),
    mana: 10,
    level:level
    )
    {
        _xpReward = 15 + (level * 5);
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