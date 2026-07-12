class Orc : Monster
{
    public Orc(string name, int level) :  base(name, 
    maxHp: 70 +(level*22), 
    speed: 8 + level,
    defense: 4 + (level * 2) , 
    stamina: 50 + (level *5), 
    strength: 14 + (level *4),
    mana: 10,
    level:level
    )
    {
        _xpReward = 25 + (level * 10);
    }
}