public abstract class  Character
{
    protected string _name;
    protected int _health;
    protected int _maxHealth;
    protected int _lvl;
    protected double _speed;
    protected double _defense;
    protected int _stamina;
    protected int _currentStamina;
    protected double _strength;
    protected int _mana;
    protected int _currentMana;
    protected virtual double _attackPower => _strength;


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

    public abstract void TakeTurn();

    public abstract void Attack();

    public virtual void TakeDamage(int damage)
    {
        // what code would look like
        // _health = Math.Clamp(_health - damage, 0, _maxHealth);
        // Console.WriteLine($"{_name} took damage! HP: {_health/_maxHealth}");
    }

    public bool IsAlive => _health > 0;

    public virtual void RecievedHealing(int amount)
    {
        if (!IsAlive) return;
        _health = Math.Clamp(_health + amount, 0, _maxHealth);
        Console.WriteLine($"{_name} was healed for {amount} HP! ({_health}/{_maxHealth})");
    }

    // Code to help calculate the probabilty of missing an attack
    public virtual void StaminaMultiplier(){
    // stamina Miss percentage mulitplier
    Random rand = new Random();

    // Calculate current stamina percentage (e.g., 20/100 = 0.2)
    double staminaPct;
    staminaPct = _currentStamina / _stamina;

    // Base accuracy is 95%. If stamina drops below 50%, reduce accuracy proportionally
    double accuracy = 0.95;
    if (staminaPct < 0.25)
    {
        accuracy -= (0.75 - staminaPct); // e.g., at 10% stamina, accuracy drops by 0.4 (down to 55%)
    }

    // Roll a decimal between 0.0 and 1.0
    if (rand.NextDouble() > accuracy)
    {
        Console.WriteLine($"{_name} is exhausted and MISSED the attack!");
    }
    }

}