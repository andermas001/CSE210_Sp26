class Healer : Hero
{
    public override double AttackPower
    {
       get => (Mana / 8) + (Lvl * 2);
    }
    private double _healingPower;
    public int HealingPower{
        get => (Mana / 4) + (Lvl * 5);
    }

    // string name, int maxHp, int speed, int defense, int stamina, int strength)
    public Healer(string name) : 
    base(name, maxHp: 110, speed:11, defense:5, stamina: 100, strength: 5, mana: 100)
    {
        
    }

    public override void LevelUp()
    {
        Lvl ++;
        MaxHealth += 15;
        Strength += 1;
        Stamina += 5;
        Speed += 2;
        Mana += 10;
        // _currentMana =_mana; 
        // fill mana on level up?
        // fill health on level up?
    }


    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        Defending = false;
        Console.WriteLine($"\n--- {Name}'s Turn (Healer) ---");
        Console.WriteLine($"HP: {Health}/{MaxHealth} | Mana: {CurrentMana}/{Mana}");
        Console.WriteLine("1. Cast Heal (20 Mana): single target heal"); // single target heal (high amount)
        Console.WriteLine("2. Cast area heal (25 Mana): Area heal");    // multi target attack(area heal)
        Console.WriteLine("3. Cast attack buff (30 mana): Single target buff"); 
        Console.WriteLine("4. Cast simple attack (5 mana): Small damage attack"); 
        Console.WriteLine("5. Staff Bonk (0 Mana)");
        
        Console.Write("Choose an action: ");
        string choice = Console.ReadLine();

        Character target;
        Character ally; 

        if (choice == "1" && CurrentMana >= 20)
        {   
            ally = ChooseAlly(allies);
            if (ally == null) return;
            CurrentMana -= 20;
            CurrentStamina -=5;
            ally.RecievedHealing(HealingPower); // Uses Mana-scaled AttackPower
        }
        else if (choice == "2" && CurrentMana >= 25)
        {
            if (allies == null) return;
            CurrentMana -= 25;
            CurrentStamina -=5;
            foreach (Character i in allies)
            {
                i.RecievedHealing(HealingPower/3);
            }
        }
        else if (choice == "3" && CurrentMana >= 30)
        {
            ally = ChooseTarget(allies);
            if (ally == null) return;
            CurrentMana -= 30;
            CurrentStamina -=5;
            ally.RecievedBuff(HealingPower);
            
        }
        else if (choice == "4" && CurrentMana >= 5)
        {
            target = ChooseTarget(enemies);
            if (target == null) return;
            CurrentMana -= 5;
            CurrentStamina -=5;
            target.TakeDamage(AttackPower);
        }
        else if (choice == "5" )
        {
            target = ChooseTarget(enemies);
            if (target == null) return;
            CurrentStamina -=10;
            target.TakeDamage(Strength);
        }
        else
        {
            
        }

        
    }


}