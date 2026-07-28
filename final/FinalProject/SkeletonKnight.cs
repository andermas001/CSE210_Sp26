class SkeletonKnight : Monster
{
    public SkeletonKnight(string name, int level) : base(name,
        maxHp: 80 + (level * 25),
        speed: 5 + (level * 1),
        defense: 10 + (level * 4),
        stamina: 60 + (level * 5),
        strength: 10 + (level * 3),
        mana: 0,
        level: level
    )
    {
        _xpReward = 35 + (level * 9);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        Character target = enemies.Where(h => h.IsAlive).OrderByDescending(h => h.Strength).FirstOrDefault();
        if (target != null)
        {
            Console.WriteLine($"\n🛡️ {Name} (Skeleton Knight) raises a heavy iron shield and crushes {target.Name}!");
            target.TakeDamage(Strength);
        }
    }
}