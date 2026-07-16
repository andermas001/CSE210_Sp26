class Golem : Monster
{
    public Golem(string name, int level) :  base(name, 
    maxHp: 110 +(level*35), 
    speed: 3 + (level * .5),
    defense: 12 + (level * 5) , 
    stamina: 50 + (level * 2), 
    strength: 11 + (level * 3),
    mana: 10,
    level:level
    )
    {
        _xpReward = 30 + (level * 10);
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