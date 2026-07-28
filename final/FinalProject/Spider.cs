class CaveSpider : Monster
{
    public CaveSpider(string name, int level) : base(name,
        maxHp: 20 + (level * 8),
        speed: 15 + (level * 4),
        defense: 0 + (level * 1),
        stamina: 60 + (level * 5),
        strength: 4 + (level * 2),
        mana: 15,
        level: level
    )
    {
        _xpReward = 12 + (level * 4);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        // Targets the hero with the highest speed to slow/disrupt them
        Character target = enemies.Where(h => h.IsAlive).OrderByDescending(h => h.Speed).FirstOrDefault();

        if (target != null)
        {
            Console.WriteLine($"\n🕷️ {Name} leaps from the ceiling and bites {target.Name}!");
            double rawDamage = Strength;
            target.TakeDamage(rawDamage);
        }
    }
}