class Necromancer : Monster
{
    public Necromancer(string name, int level) : base(name,
        maxHp: 50 + (level * 15),
        speed: 9 + (level * 2),
        defense: 2 + (level * 1.5),
        stamina: 50 + (level * 4),
        strength: 4 + (level * 1.5),
        mana: 80 + (level * 15),
        level: level
    )
    {
        _xpReward = 50 + (level * 12);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        // 1. Summon an Undead Minion if ally count is below 3
        if (allies.Count < 3 && CurrentMana >= 20)
        {
            CurrentMana -= 20;
            Console.WriteLine($"\n🔮 {Name} (Necromancer) chants in an ancient tongue, raising a new Undead Minion!");
            allies.Add(new UndeadMinion("Crawling Thrall", Lvl));
            return;
        }

        // 2. Dark Bolt attack targeting lowest current HP
        Character target = enemies.Where(h => h.IsAlive).OrderBy(h => h.Health).FirstOrDefault();
        if (target != null)
        {
            Console.WriteLine($"\n⚡ {Name} hurls a bolt of necro-energy at {target.Name}!");
            target.TakeDamage(Strength + (Lvl * 3));
        }
    }
}