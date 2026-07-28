class UndeadMinion : Monster
{
    public UndeadMinion(string name, int level) : base(name,
        maxHp: 20 + (level * 8),
        speed: 6 + (level * 1.5),
        defense: 1 + (level * 1),
        stamina: 40 + (level * 3),
        strength: 5 + (level * 2),
        mana: 0,
        level: level
    )
    {
        _xpReward = 8 + (level * 2);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        Character target = enemies.Where(h => h.IsAlive).OrderByDescending(h => h.Health).FirstOrDefault();
        if (target != null)
        {
            Console.WriteLine($"\n🧟 {Name} (Undead Minion) drags itself across the ground and bites {target.Name}!");
            target.TakeDamage(Strength);
        }
    }
}