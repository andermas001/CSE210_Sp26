public abstract class  Character
{
    private string _name;
    private int _health;
    private int _maxHealth;
    private int _lvl;
    private double _speed;
    private double _defense;
    private int _stamina;
    private int _currentStamina;
    private double _strength;
    private int _mana;
    private int _currentMana;
    private bool _defending;
    private int _buffedTurnsRemaining;
    private bool _buffed;
    private double _bonusAttackPower;
    private double _shield;

    private List<Item> _inventory = new List<Item>();
    private Equipment _equippedWeapon;
    private Equipment _equippedArmor;

    // constructor
    // turn construtor to protected to insure that there are no character entities. 
    protected Character(string name, int maxHp, double speed, double defense, int stamina, double strength, int mana)
    {
        _name = name;
        _maxHealth = maxHp;
        _speed = speed;
        _defense = defense;
        _stamina = stamina;
        _strength = strength;
        _health = _maxHealth;
        _mana = mana;
        _currentMana = _mana;
        _currentStamina = _stamina;
        _lvl = 1;
    }

    // Getters and setters
    public string Name
    {
        get => _name;
        protected set => _name = value ?? throw new ArgumentException("Name cannot be null");
    }
    public int Health
    {
        get=> _health;
        protected set
        {
            _health = Math.Clamp(value, 0, _maxHealth);
        }
    }
    public int MaxHealth
    {
        get => _maxHealth;
        protected set => _maxHealth = value;
    }
    public int Lvl
    {
        get => _lvl;
        protected set => _lvl = (value > 0)
        ? value
        : throw new ArgumentOutOfRangeException("level cannot be less then 0");
    }
    public double Speed
    {
        get => _speed;
        protected set => _speed = value;
    }
    public double Defense
    {
        get => _defense + (_equippedArmor?.BonusDefense ?? 0);
        protected set => _defense = value;
    }
    public int Stamina{
        get => _stamina;
        protected set { _stamina = value;
        }
    }
    public int CurrentStamina
    {
        get => _currentStamina;
        protected set 
        {
            _currentStamina = Math.Clamp(value, 0, _stamina);
        }
    }
    public double Strength
    {
        get => _strength;
        protected set => _strength = value;
    }
    public int Mana
    {
        get => _mana;
        protected set => _mana = value;
    }
    public int CurrentMana 
    {
        get => _currentMana;
        protected set => _currentMana = (value > -1 && value <= _mana) 
        ? value 
        : throw new ArgumentOutOfRangeException("mana cannot be lower then 0 or higher then the max mana");
    }
    public List<Item> Inventory => _inventory;
    public Equipment EquippedWeapon => _equippedWeapon;
    public Equipment EquippedArmor => _equippedArmor;
    public virtual double AttackPower
    {
        get => _strength + BonusAttackPower + (_equippedWeapon?.BonusStrength ?? 0);
    }
    
    public bool Defending
    {
        get => _defending;
        protected set => _defending = value;
    }
    
    public int BuffedTurnsRemaining => _buffedTurnsRemaining;

    public double BonusAttackPower => _bonusAttackPower;

    public bool Buffed
    {
        get => _buffed;
        protected set => _buffed = value; 
    } 
    
    public bool IsAlive 
    {
        get => _health > 0;
    }

    public double Shield
    {
        get => _shield;
        protected set 
        {
            _shield = Math.Clamp(value, 0, value);
        }
    }

    public int XpThreshold
    {
        get => (int)Math.Floor(100 * Math.Pow(Lvl, 1.2));
    }

    // methods for combat and running system

    public abstract void TakeTurn(List<Character> allies, List<Character> enemies);

    public virtual void TakeDamage(double damage)
    {
        double finalDamage = damage;
        if (Shield > 0)
        {
            if (finalDamage <= Shield)
            {
                Shield =- finalDamage;
                Console.WriteLine($"🛡️ {Name}'s shield absorbed ALL {finalDamage} damage! (Shield left: {Shield})");
                return;
            }

            else
            {
                double absorbed = Shield;
                finalDamage -= Shield;
                Shield = 0;
                Console.WriteLine($"🛡️ {Name}'s shield broke after absorbing {absorbed} damage!");
            }
        }
        Health = (int )(Math.Clamp(_health - finalDamage, 0, _maxHealth));
        Console.WriteLine($"{_name} took {finalDamage} damage! HP: {Health}/{MaxHealth}");

        if (!IsAlive)
        {
            Console.WriteLine($"💀 {_name} has been defeated!");
        }
    }

    public virtual void RecievedHealing(int amount)
    {
        if (!IsAlive) return;
        _health = Math.Clamp(_health + amount, 0, _maxHealth);
        Console.WriteLine($"{_name} was healed for {amount} HP! ({Health}/{MaxHealth})");
    }

    // Code to help calculate the probabilty of missing an attack
    public virtual bool CalculateMiss()
    {
        // stamina Miss percentage mulitplier

        Random rand = new Random();

        // Calculate current stamina percentage (e.g., 20/100 = 0.2)
        double staminaPct;
        staminaPct = (double)_currentStamina / _stamina;

        // Base accuracy is 95%. If stamina drops below 25%, reduce accuracy proportionally
        double accuracy = 0.95;
        if (staminaPct < 0.25)
        {
            accuracy = -0.00008 * Math.Pow(staminaPct, 2) + 0.012 * staminaPct + .60;  // accuracy = 85% at 25, and lowers to 60% at 0.
        }
        // Roll a decimal between 0.0 and 1.0
        if (rand.NextDouble() > accuracy)
        {
            Console.WriteLine($"{_name} is exhausted and MISSED the attack!");
            return true;
        }
        else
        return false;
    }

    public virtual void RecievedBuff(double bonusDamage, int durationTurns)
    {
        if (!IsAlive) return;

        _bonusAttackPower = bonusDamage;
        _buffedTurnsRemaining = durationTurns;
        Console.WriteLine($"🔥 {Name} received a +{bonusDamage} Attack Power buff for {durationTurns} turns!");
        Buffed = true;
    }

    protected virtual void IsDefending()
    {
        _defending = true;
        while (_defending == true)
        {
            Defense = Defense * 3;
        }
    }

    // choose ally and choose taget will allow for the user to chose a target to attack or choose a ally to help or heal
    public virtual Character ChooseTarget(List<Character> Enemies)
    {
        return null;
    }

    public virtual Character ChooseAlly(List<Character> allies)
    {
        return null;
    }

    public virtual void RefillStamina(int amount)
    {
        if (!IsAlive) return;
        _currentStamina = Math.Clamp(_currentStamina + amount, 0, _stamina);
        Console.WriteLine($"{_name} has rested | Stamina:({_currentStamina}/{_stamina})");
    }

    public virtual void RefillMana(int amount)
    {
        if (!IsAlive) return;
        _currentMana = Math.Clamp(_currentMana + amount, 0, _mana);
        Console.WriteLine($"{_name} has rested | Mana: ({_currentMana}/{_mana})");
        
    }

    public virtual void ApplyShield(double amount)
    {
        if (!IsAlive) return;
        Shield += amount;
        Console.WriteLine($"🛡️ {Name} gained a {amount} HP shield! (Total Shield: {Shield})");
    }

    public virtual void UpdateStatusEfffects()
    {
        if (_buffedTurnsRemaining > 0)
        {
            _buffedTurnsRemaining --;

            if (_buffedTurnsRemaining == 0)
            {
                _bonusAttackPower = 0;
                Buffed = false;
                Console.WriteLine($"⌛ {Name}'s Attack Power buff has expired.");
            }
            else
            {
                Console.WriteLine($"🔥 {Name}'s buff is active (+{_bonusAttackPower} ATK, {_buffedTurnsRemaining} turns left).");
            }
        }
    }

    public void EquipItem(Equipment equip)
    {
        if (equip.Type == ItemType.Weapon)
        {
            _equippedWeapon = equip;
            Console.WriteLine($"⚔️ {Name} equipped {equip.Name}! (+{equip.BonusStrength} ATK)");
        }
        else if (equip.Type == ItemType.Armor)
        {
            _equippedArmor = equip;
            Console.WriteLine($"🛡️ {Name} equipped {equip.Name}! (+{equip.BonusDefense} DEF)");
        }
    }
}