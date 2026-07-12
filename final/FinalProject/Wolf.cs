class Wolf : Monster
{
    public Wolf(string name, int level) :  base(name, 
    maxHp: 45 +(level*12), 
    speed: 16 + (level * 4),
    defense: 2 + (level * 0.5) , 
    stamina: 50 + (level * 10), 
    strength: 8 + (level * 2.5),
    mana: 10,
    level:level
    )
    {
        _xpReward = 25 + (level * 10);
    }
}
