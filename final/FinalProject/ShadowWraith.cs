class ShadowWraith : Monster
{
    public ShadowWraith(string name, int level) : base(name,
        maxHp: 40 + (level * 12),
        speed: 11 + (level * 2),
        defense: 5 + (level * 2),
        stamina: 60 + (level * 5),
        strength: 8 + (level * 2),
        mana: 30,
        level: level
    )
    {
        _xpReward = 30 + (level * 8);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        // Targets the strongest physical damage dealer in your party
        Character target = enemies.Where(h => h.IsAlive).OrderByDescending(h => h.Strength).FirstOrDefault();

        if (target != null)
        {
            Console.WriteLine($"\n👻 {Name} phases through the floor and drains energy from {target.Name}!");
            target.TakeDamage(Strength);
        }
    }
}