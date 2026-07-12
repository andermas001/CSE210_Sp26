class Golem : Monster
{
    public Golem(string name, int level) :  base(name, 
    maxHp: 110 +(level*35), 
    speed: 3 + (level * .5),
    defense: 12 + (level * 5) , 
    stamina: 50 + (level * 2), 
    strength: 11 + (level * 3),
    mana: 10,
    level:level
    )
    {
        _xpReward = 30 + (level * 10);
    }
}