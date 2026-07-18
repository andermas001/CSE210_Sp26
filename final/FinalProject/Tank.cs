class Tank : Hero
{

    public override double AttackPower
    {
       get => Strength;
    }

    // string name, int maxHp, int speed, int defense, int stamina, int strength)
    public Tank(string name) : 
    base(name, maxHp: 220, speed:6, defense:14, stamina: 120, strength: 12, mana: 10)
    {
        
    }

    public override void LevelUp()
    {
        Lvl ++;
        MaxHealth += 35;
        Defense += 4;
        Speed += 1;
        Strength += 3;
        Stamina += 8;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✨ LEVEL UP! {Name} reached Level {Lvl}! ✨");
        Console.ResetColor();
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        Defending = false; // Reset defense stance at start of turn
        Console.WriteLine($"\n--- {Name}'s Turn (Tank) ---");
        Console.WriteLine($"HP: {Health}/{MaxHealth} | Stamina: {CurrentStamina}/{Stamina}");
        Console.WriteLine("1. Light Attack (0 Stamina, standard damage)");
        Console.WriteLine("2. Heavy Bash (25 Stamina, high damage)");
        Console.WriteLine("3. Defend (0 Stamina, reduces incoming damage next round)");
        Console.WriteLine("4. Rest (Regain stamina and Mana)");
        
        Console.Write("Choose an action: ");
        string choice = Console.ReadLine();

        if (choice == "3")
        {
            IsDefending();
            Console.WriteLine($"{Name} raised their shield!");
            return;
        }

        // Target selection helper
        Character target;

        // Check stamina rule for missing odds
        if (choice == "2" && CurrentStamina >= 25)
        {
            target = ChooseTarget(enemies); // enemies);
            if (target == null) return;
            CurrentStamina -= 25;
            if (!CalculateMiss()) // 25% lower stamina accuracy penalty
            {
                target.TakeDamage(AttackPower + 20);
            }
        }
        else if (choice == "1") // Default to Light Attack
        {
            target = ChooseTarget(enemies); // enemies);
            if (target == null) return;
            if (!CalculateMiss()) 
            {
                target.TakeDamage(AttackPower);
            }
        }
        else
        {
            RefillStamina(50);
            RefillMana(50);
        }
    }

}