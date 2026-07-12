abstract class  Character
{
    private string _name;
    private int _stamina;
    private int _health;
    private int _maxHealth;
    private int _strength;
    private int _mana;
    private int _lvl;
    private int _speed;
    private int _defense;

    // turn construtor to protected to insure that there are no charated entities. 
    public Character(string name, int maxHp, int speed, int defense, int stamina, int strength)
    {
        _name = name;
        _maxHealth = maxHp;
        _speed = speed;
        _defense = defense;
        _stamina = stamina;
        _strength = strength;
        _lvl = 1;
        _health = _maxHealth;
    }
    
    public abstract void TakeTurn(Character Target);

    public abstract void Attack(int damage);

    public virtual void TakeDamage(int damage)
    {
        _health = Math.Clamp(_health - damage, 0, _maxHealth);
        Console.WriteLine($"{_name} took damage! HP: {_health/_maxHealth}");
    }

    public bool IsAlive => _health > 0;


}