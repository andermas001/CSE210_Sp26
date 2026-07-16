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
    private  double _attackPower;
    private bool _defending;
    private bool _buffed;
    private bool _isAlive;

    // constructor
    // turn construtor to protected to insure that there are no charated entities. 
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
        protected set => _health = (value >= 0 && value <= _maxHealth) 
        ? value 
        : throw new ArgumentOutOfRangeException("Health must be higher then 0 and lower then the max health");
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
        get => _defense;
        protected set => _defense = value;
    }
    public int Stamina{
        get => _stamina;
        protected set => _stamina = (value > -1) 
        ? value 
        : throw new ArgumentOutOfRangeException("stamina cannot be lower then 0");
    }
    public int CurrentStamina{
        get => _currentStamina;
        protected set => _currentStamina = (value > -1 && value <= _stamina) 
        ? value 
        : throw new ArgumentOutOfRangeException("stamina cannot be lower then 0 or higher then the max stamina");
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
    public virtual double AttackPower
    {
       get => _attackPower;
       protected set => _attackPower = _strength;
    }
    
    public bool Defending
    {
        get => _defending;
        protected set => _defending = value;
    }
    
    public bool Buffed
    {
        get => _buffed;
        protected set => _buffed = value;
    }
    public bool IsAlive 
    {
        get => _isAlive;
        protected set => _isAlive = _health > 0;
    }

    // methods for combat and running system

    public abstract void TakeTurn(List<Character> allies, List<Character> enemies);

    public virtual void TakeDamage(double damage)
    {
        // what code would look like
        // _health = Math.Clamp(_health - damage, 0, _maxHealth);
        // Console.WriteLine($"{_name} took damage! HP: {_health/_maxHealth}");
    }

    public virtual void RecievedHealing(int amount)
    {
        if (!IsAlive) return;
        _health = Math.Clamp(_health + amount, 0, _maxHealth);
        Console.WriteLine($"{_name} was healed for {amount} HP! ({_health}/{_maxHealth})");
    }

    // Code to help calculate the probabilty of missing an attack
    public virtual bool CalculateMiss()
    {
        // stamina Miss percentage mulitplier

        Random rand = new Random();

        // Calculate current stamina percentage (e.g., 20/100 = 0.2)
        double staminaPct;
        staminaPct = _currentStamina / _stamina;

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

    public virtual void RecievedBuff(int amount)
    {
        if (!IsAlive) return;
        _strength = _strength + amount;
        Console.WriteLine($"{_name} was buffed for {amount} damage! ");
        _buffed = true;
    }

    protected virtual bool IsDefending()
    {
        return _defending = true;
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
}