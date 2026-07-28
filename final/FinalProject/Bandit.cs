class Bandit : Monster
{
    public Bandit(string name, int level) : base(name,
        maxHp: 32 + (level * 10),
        speed: 13 + (level * 3),
        defense: 2 + (level * 1.5),
        stamina: 60 + (level * 5),
        strength: 8 + (level * 2.5),
        mana: 0,
        level: level
    )
    {
        _xpReward = 20 + (level * 5);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        Character target = enemies.Where(h => h.IsAlive).OrderBy(h => h.Health).FirstOrDefault();
        if (target != null)
        {
            Console.WriteLine($"\n🗡️ {Name} (Bandit) steps from the shadows and backstabs {target.Name}!");
            target.TakeDamage(Strength * 1.2); // 20% bonus backstab damage
        }
    }
}