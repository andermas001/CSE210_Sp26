class SkeletonArcher : Monster
{
    public SkeletonArcher(string name, int level) : base(name,
        maxHp: 25 + (level * 7),
        speed: 10 + (level * 2.5),
        defense: 1 + (level * 1),
        stamina: 40 + (level * 4),
        strength: 7 + (level * 2.5),
        mana: 0,
        level: level
    )
    {
        _xpReward = 18 + (level * 5);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        // Snipes the hero with the lowest current Health
        Character target = enemies.Where(h => h.IsAlive).OrderBy(h => h.Health).FirstOrDefault();

        if (target != null)
        {
            Console.WriteLine($"\n🏹 {Name} draws a bone arrow and snipes {target.Name}!");
            target.TakeDamage(Strength);
        }
    }
}