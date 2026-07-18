class BattleEngine
{
    private List<Character> _turnOrder;

    private List<Character> _allies;
    private List<Character> _enemies;

    public bool StartInteraction(List<Character> startingaliies, List<Character> startingEnemies)
    {
        _allies = new List<Character>(startingaliies);
        _enemies = new List<Character>(startingEnemies);
        _turnOrder = new List<Character>();

        Console.WriteLine("Battle Start! \n");

        while (BothSidesHaveSurvivors())
        {
            RunRound();
        }
        ResolveBattleOutcome();

        bool playerVictory = _allies.Any(a => a.IsAlive);
        return playerVictory;
    }

    private bool BothSidesHaveSurvivors()
    { // Will run to see if the battle is over 
        bool alliesAlive = _allies.Any(a => a.IsAlive);
        bool enemiesAlive = _enemies.Any(a => a.IsAlive);
        if (alliesAlive && enemiesAlive)
        {
            return true;
        }
        else return false;
    }

    private void RunRound()
    {
        _turnOrder.Clear();
        _turnOrder.AddRange(_allies);
        _turnOrder.AddRange(_enemies);
        // Speed to be replaced by a getter for speed
        _turnOrder = _turnOrder
            .OrderByDescending(c => c.IsAlive)
            .ThenByDescending(c => c.Speed)
            .ToList();
        
        foreach(var combatant in _turnOrder)
        {
            if (!combatant.IsAlive)
            {
                continue;
            }

            if (!_enemies.Any(e => e.IsAlive) || !_allies.Any(a => a.IsAlive)) break;

            if (!BothSidesHaveSurvivors())
            {
                break;
            }

            if (_allies.Contains(combatant))
            {
                combatant.TakeTurn(_allies, _enemies);
            }

            else
            {
                combatant.TakeTurn(_enemies, _allies);
            }

            Console.WriteLine();
        }
    }

    private void ResolveBattleOutcome()
    {
        Console.WriteLine("====================================");
        Console.WriteLine("          BATTLE RESOLVED           ");
        Console.WriteLine("====================================\n");

        bool partySurvived = _allies.Any(a => a.IsAlive);

        if (partySurvived)
        {
            Console.WriteLine("Victory! Your party has defeated your oponents \n");

            // Calcualte XP
            int totalXp = 0;
            foreach(var combatant in _enemies)
            {
                if (combatant is Monster monster)
                {
                    totalXp += monster.XpGiven();
                }
            }

            var survivors = _allies.OfType<Hero>().Where(h => h.IsAlive).ToList();

            if (survivors.Count > 0)
            {
                double xpPerhero = totalXp / survivors.Count;
                Console.WriteLine($"your party earned {totalXp} XP! Distributing {xpPerhero} XP to survivors");

                foreach (var hero in survivors)
                {
                    hero.GainXp(xpPerhero);
                }
            }
            else
            {
                Console.WriteLine("💀 DEFEAT! Your party has been wiped out... Game Over.");
            }
        }
    }
}