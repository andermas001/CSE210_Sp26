public enum ItemType { Consumable, Weapon, Armor}

public abstract class Item
{
    private string _name;
    private string _itemDescription;
    private ItemType _type;
    private int _value;

    protected Item(string name, string description, ItemType type, int value)
    {
        _name = name;
        _itemDescription = description;
        _type = type;
        _value = value; 
    }

    // properties

    public string Name => _name;

    public string ItemDescription => _itemDescription;

    public ItemType Type => _type;

    public int Value => _value;

    public abstract void Use(Character user);
}