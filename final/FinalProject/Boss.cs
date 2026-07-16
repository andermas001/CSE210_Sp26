class Boss : Monster
{
    public Boss(string name, int level) :  base(name, 
    maxHp: 350 +(level*75), 
    speed: 10 + (level * 2),
    defense: 10 + (level * 4) , 
    stamina: 50 + (level * 10), 
    strength: 25 + (level * 5),
    mana: 10,
    level:level
    )
    {
        _xpReward = 200 + (level * 50);
    }
    private int _turnCycle = 1;

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        Defending = false; // Reset defense stance

        // Get all living heroes
        var livingHeroes = enemies.Where(h => h.IsAlive).ToList();
        if (livingHeroes.Count == 0) return;

        switch (_turnCycle)
        {
            case 1:
                // Turn 1: Smash the strongest hero (the Tank)
                Character heavyTarget = livingHeroes.OrderByDescending(h => h.MaxHealth).First();
                Console.WriteLine($"\n☠️ {Name} (BOSS) focuses its gaze on {heavyTarget.Name} and delivers a crushing blow!");
                heavyTarget.TakeDamage(Strength + 15);
                _turnCycle = 2;
                break;

            case 2:
                // Turn 2: Cast defensive barrier (Guard) and recover some HP
                Console.WriteLine($"\n🛡️ {Name} (BOSS) channels a dark barrier, raising its defense and recovering energy!");
                Defending = true;
                RecievedHealing(Lvl * 10); // Heals itself
                _turnCycle = 3;
                break;

            case 3:
                // Turn 3: Ultimate AOE Ground Slam! Hits ALL living heroes at once
                Console.WriteLine($"\n💥 {Name} (BOSS) slams the ground! Shockwaves rip through your entire party!");
                foreach (var hero in livingHeroes)
                {
                    double partialDamage = Strength - 10; // Slightly weaker than single target, but hits everyone
                    hero.TakeDamage(partialDamage);
                }
                _turnCycle = 1; // Reset cycle
                break;
        }
    }
}