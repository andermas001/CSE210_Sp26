class Boss : Monster
{
     public Boss(string name, int level) :  base(name, 
    maxHp: 350 +(level*75), 
    speed: 10 + (level * 2),
    defense: 10 + (level * 4) , 
    stamina: 50 + (level * 10), 
    strength: 25 + (level * 5),
    mana: 10,
    level:level
    )
    {
        _xpReward = 200 + (level * 50);
    }
}