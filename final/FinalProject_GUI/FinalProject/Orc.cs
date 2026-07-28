class Orc : Monster
{
    public Orc(string name, int level) :  base(name, 
    maxHp: 70 +(level*22), 
    speed: 8 + level,
    defense: 4 + (level * 2) , 
    stamina: 50 + (level *5), 
    strength: 14 + (level *4),
    mana: 10,
    level:level
    )
    {
        _xpReward = 25 + (level * 10);
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        // Golems blindly target whoever has the highest max health (usually the Tank)
        Character target = enemies.Where(h => h.IsAlive).OrderByDescending(h => h.Health ).FirstOrDefault();
        
        if (target != null)
        {
            double hpPercent = (double)Health / MaxHealth;

            if (hpPercent < 0.4) // Enraged mode!
            {
                Console.WriteLine($"\n😡 {Name} (Orc) is low on health and flies into a bloodthirsty RAGE!");
                
                // 30% chance to miss when raging
                Random rand = new Random();
                if (rand.NextDouble() < 0.30)
                {
                    Console.WriteLine($"{Name} swings wildly and MISSED!");
                }
                else
                {
                    Console.WriteLine($"{Name} delivers a devastating heavy swing!");
                    target.TakeDamage(Strength * 1.5); // Double damage
                }
            }
            else
            {
                Console.WriteLine($"\n🪓 {Name} (Orc) roars and swings its battleaxe at {target.Name}!");
                target.TakeDamage(Strength);
            }
        }
    }
}