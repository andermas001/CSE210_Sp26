class DarkCultist : Monster
{
    public DarkCultist(string name, int level) : base(name,
        maxHp: 25 + (level * 9),
        speed: 8 + (level * 2),
        defense: 2 + (level * 1),
        stamina: 40 + (level * 3),
        strength: 3 + (level * 1.5),
        mana: 50 + (level * 10),
        level: level
    )
    {
        _xpReward = 20 + (level * 6);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        // Priority 1: Check if an ally mob is below 50% HP
        Character woundedAlly = allies.Where(m => m.IsAlive && m.Health < (m.MaxHealth * 0.5))
                                      .OrderBy(m => m.Health)
                                      .FirstOrDefault();

        if (woundedAlly != null && CurrentMana >= 15)
        {
            int healAmount = 15 + (Lvl * 5);
            CurrentMana -= 15;
            Console.WriteLine($"\n✨ {Name} chants dark incantations, healing {woundedAlly.Name} for {healAmount} HP!");
            woundedAlly.RecievedHealing(healAmount);
            return;
        }

        // Priority 2: Mind Blast the lowest defense hero
        Character target = enemies.Where(h => h.IsAlive).OrderBy(h => h.Defense).FirstOrDefault();
        if (target != null)
        {
            Console.WriteLine($"\n🔮 {Name} fires a bolt of dark energy at {target.Name}!");
            target.TakeDamage(Strength + (Lvl * 2));
        }
    }
}