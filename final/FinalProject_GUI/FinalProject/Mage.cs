class Mage : Hero
{
   // Clean, read-only override. No setter implied.
    public override double AttackPower
    {
       get => (Mana / 4) + (Lvl * 5);
    } 

    // level Scaling Hp: 10, speed: 2, defense: 1, strength: 2, stamina: 5, mana 10

    public Mage(string name) : base(name, maxHp: 100, speed:14, defense:3, stamina: 70, strength: 10, mana: 100)
    {
    }

    public override void LevelUp()
    {
        Lvl ++;
        MaxHealth += 10;
        Defense += 1;
        Speed += 2;
        Strength += 2;
        Stamina += 5;
        Mana += 10;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✨ LEVEL UP! {Name} reached Level {Lvl}! ✨");
        Console.ResetColor();
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        Defending = false;
        Console.WriteLine($"\n--- {Name}'s Turn (Mage) ---");
        Console.WriteLine($"HP: {Health}/{MaxHealth} | Mana: {CurrentMana}/{Mana}");
        Console.WriteLine("1. Cast Fireball (20 Mana): single target attack");  // single target attack (high damage)
        Console.WriteLine("2. Cast Schorching Wave (30 Mana): Area of effect attack");  // multi target attack(area damage)
        Console.WriteLine("3. Staff Bonk (0 Mana)");
        Console.WriteLine("4. Rest (Regain stamina and Mana)");
        
        Console.Write("Choose an action: ");
        string choice = Console.ReadLine();
        Console.WriteLine();

        Character target;
        if (choice == "1" && CurrentMana >= 20 && CurrentStamina >= 5)
        {
            target = ChooseTarget(enemies);
            if (target == null) return;
            CurrentMana -= 20;
            CurrentStamina -=5;
            target.TakeDamage(AttackPower); // Uses Mana-scaled AttackPower
        }
        else if (choice == "2" && CurrentMana >= 30 && CurrentStamina >= 5)
        {
            if (enemies == null)
            {
                return;
            }
            CurrentMana -= 30;
            CurrentStamina -=5;
            foreach (Character i in enemies)
            {
                i.TakeDamage(AttackPower/3);
            }
        }
        else if (choice == "3" && CurrentStamina > 10)
        {
            target = ChooseTarget(enemies);
            CurrentStamina -= 10;
            target.TakeDamage(Strength); // Base low physical strength bonk
        }
        else
        {
            RefillStamina(50);
            RefillMana(50);
        }
        Console.WriteLine();
    }


}