class Slime : Monster
{
    public Slime(string name, int level) : base(name,
        maxHp: 55 + (level * 18),
        speed: 4 + (level * 1),
        defense: 6 + (level * 2.5),
        stamina: 60 + (level * 4),
        strength: 6 + (level * 2),
        mana: 0,
        level: level
    )
    {
        _xpReward = 15 + (level * 4);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        Character target = enemies.Where(h => h.IsAlive).OrderBy(h => h.Speed).FirstOrDefault();
        if (target != null)
        {
            Console.WriteLine($"\n🟢 {Name} (Slime) squishes forward and engulfs {target.Name} in acid!");
            target.TakeDamage(Strength);
        }
    }
}