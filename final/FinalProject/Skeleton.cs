class Skeleton : Monster
{
    public Skeleton(string name, int level) : base(name,
        maxHp: 35 + (level * 12),
        speed: 8 + (level * 2),
        defense: 3 + (level * 2),
        stamina: 50 + (level * 4),
        strength: 7 + (level * 2.5),
        mana: 0,
        level: level
    )
    {
        _xpReward = 18 + (level * 5);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        Character target = enemies.Where(h => h.IsAlive).OrderBy(h => h.Defense).FirstOrDefault();
        if (target != null)
        {
            Console.WriteLine($"\n💀 {Name} (Skeleton) rattles forward and slashes at {target.Name}!");
            target.TakeDamage(Strength);
        }
    }
}