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

    public override void TakeTurn(List<Character> allies, List<Character> enemies)
    {
        // Wolves act like a pack and target the weakest living character (lowest current HP)
        Character target = enemies.Where(h => h.IsAlive).OrderBy(h => h.AttackPower).FirstOrDefault(); // or track CurrentHp
        
        if (target != null)
        {
            Console.WriteLine($"\n🐺 {_name} lunges at the weakest target, {target._name}!");
            double rawDamage = _strength
            target.TakeDamage(rawDamage);
        }
    }
}
