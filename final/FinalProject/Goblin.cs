class Goblin : Monster
{
    public Goblin(string name, int level) :  base(name, 
    maxHp: 30 +(level*10), 
    speed: 12 + (level *3),
    defense: 1 + level, 
    stamina: 50 + (level *5), 
    strength: 5 + (level *2),
    mana: 10,
    level:level
    )
    {
        _xpReward = 15 + (level * 5);
    }
}