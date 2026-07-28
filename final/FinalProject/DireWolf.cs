class Direwolf : Monster
{
    public Direwolf(string name, int level) : base(name,
        maxHp: 45 + (level * 14),
        speed: 16 + (level * 3.5),
        defense: 3 + (level * 2),
        stamina: 70 + (level * 6),
        strength: 9 + (level * 3),
        mana: 0,
        level: level
    )
    {
        _xpReward = 25 + (level * 6);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        Character target = enemies.Where(h => h.IsAlive).OrderBy(h => h.Health).FirstOrDefault();
        if (target != null)
        {
            Console.WriteLine($"\n🐺 {Name} (Direwolf) lets out a fierce howl and bites {target.Name}!");
            target.TakeDamage(Strength);
        }
    }
}