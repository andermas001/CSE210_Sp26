class OrcCommander : Monster
{
    private bool _hasBuffed = false;

    public OrcCommander(string name, int level) : base(name,
        maxHp: 80 + (level * 25),
        speed: 7 + (level * 1.5),
        defense: 6 + (level * 2.5),
        stamina: 70 + (level * 5),
        strength: 10 + (level * 3),
        mana: 20,
        level: level
    )
    {
        _xpReward = 45 + (level * 12);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        // First turn: Warcry to buff all living ally monsters
        if (!_hasBuffed && allies.Count > 1)
        {
            _hasBuffed = true;
            Console.WriteLine($"\n🪯 {Name} lets out a deafening WARCRY, rallying the troops!");
            foreach (var ally in allies.Where(a => a.IsAlive && a != this))
            {
                ally.RecievedBuff(3 + Lvl, 3);
            }
            return;
        }

        // Subsequent turns: Heavy cleave on the healthiest hero
        Character target = enemies.Where(h => h.IsAlive).OrderByDescending(h => h.Health).FirstOrDefault();
        if (target != null)
        {
            Console.WriteLine($"\n🪓 {Name} swings a heavy broadsword at {target.Name}!");
            target.TakeDamage(Strength);
        }
    }
}