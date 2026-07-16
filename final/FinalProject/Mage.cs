class Mage : Hero
{
    public override double AttackPower
    {
        get => (Mana / 4) + (Lvl * 5);
        protected set => base.AttackPower = value; 
    }

    /*
        level Scaling Hp: 10, speed: 2, defense: 1, strength: 2, stamina: 5, mana 10
    */
    
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
    }

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        Defending = false;
        Console.WriteLine($"\n--- {Name}'s Turn (Mage) ---");
        Console.WriteLine($"HP: {Health}/{MaxHealth} | Mana: {CurrentMana}/{Mana}");
        Console.WriteLine("1. Cast Fireball (20 Mana): single staget attack");  // single target attack (high damage)
        Console.WriteLine("2. Cast Schorching Wave (30 Mana): Area of effect attack");  // multi target attack(area damage)
        Console.WriteLine("3. Staff Bonk (0 Mana)");
        
        Console.Write("Choose an action: ");
        string choice = Console.ReadLine();

        Character target = ChooseTarget(enemies);
        if (target == null) return;

        if (choice == "1" && CurrentMana >= 20)
        {
            CurrentMana -= 20;
            CurrentStamina -=5;
            target.TakeDamage(AttackPower); // Uses Mana-scaled AttackPower
        }
        else if (choice == "2" && CurrentMana >= 30)
        {
            CurrentMana -= 30;
            CurrentStamina -=5;
            foreach (Character i in enemies)
            {
                i.TakeDamage(AttackPower/3);
            }
        }
        else
        {
            CurrentStamina -= 10;
            target.TakeDamage(Strength); // Base low physical strength bonk
        }
    }


}