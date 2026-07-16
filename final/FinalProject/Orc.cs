class Orc : Monster
{
    public Orc(string name, int level) :  base(name, 
    maxHp: 70 +(level*22), 
    speed: 8 + level,
    defense: 4 + (level * 2) , 
    stamina: 50 + (level *5), 
    strength: 14 + (level *4),
    mana: 10,
    level:level
    )
    {
        _xpReward = 25 + (level * 10);
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