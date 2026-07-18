public class GameManager
{
    private List<Hero> _playerParty;

    public List<Character> ActiveParty => _playerParty.Cast<Character>().ToList();

    public GameManager()
    {
        // Initialize your starting party
        _playerParty = new List<Hero> {
            new Warrior("Valen"),
            new Mage("Lyra"),
            new Tank("Brog")
        };
    }

    // This property dynamically calculates the party level whenever you call it
    public int CurrentPartyLevel
    {
        get
        {
            if (_playerParty.Count == 0) return 1;
            double average = _playerParty.Average(hero => hero.Lvl);
            return (int)Math.Round(average);
        }
    }

    public bool TriggerRoomEncounter(int currentfloor, bool isBossRoom)
    {
        // Pass the dynamically calculated level directly to your updated spawner!
        List<Monster> enemies;
        if (isBossRoom) 
        {
            enemies = MobSpawner.GenerateBossEncounter(currentfloor);
        }
        else
        {
            enemies = MobSpawner.GenerateEncounter(currentfloor);
        }
        // Convert List<Hero> to List<Character> to feed into the BattleEngine
        List<Character> combatAllies = ActiveParty;
        List<Character> combatEnemies = enemies.Cast<Character>().ToList();

        BattleEngine engine = new BattleEngine();
        bool Victory = engine.StartInteraction(combatAllies, combatEnemies);
        return Victory;
    }

    public void TriggerBossEncounter()
    {
        List<Monster> bossFight = MobSpawner.GenerateBossEncounter(CurrentPartyLevel);

        List<Character> combatAllies = _playerParty.Cast<Character>().ToList();
        List<Character> combatEnemies = bossFight.Cast<Character>().ToList();

        BattleEngine engine = new BattleEngine();
        engine.StartInteraction(combatAllies, combatEnemies);
    }

    public bool IsPartyAlive()
    {
        return _playerParty.Any(a => a.IsAlive);
    }

    public void FullyHealParty()
    {
        foreach(var hero in _playerParty)
        {
            hero.RecievedHealing(hero.MaxHealth);
        }
    }

    public void ShowPartyStatus()
    {
        Console.WriteLine("\n================ PARTY STATUS ================");

        foreach(var hero in _playerParty)
        {
            if (!hero.IsAlive)
            {
                Console.WriteLine($"💀 {hero.Name} [Lvl {hero.Lvl}] - FALLEN");
            }

            else
            {
                Console.WriteLine($"❤️ {hero.Name} [Lvl {hero.Lvl}] | HP: {hero.Health}/{hero.MaxHealth} | Mana: {hero.CurrentMana}/{hero.Mana} | Stamina: {hero.CurrentStamina}/{hero.Stamina}");
            }
        }
        Console.WriteLine("==============================================");
        Console.WriteLine("Press Enter to return to the menu...");
        Console.ReadLine();
    }
}