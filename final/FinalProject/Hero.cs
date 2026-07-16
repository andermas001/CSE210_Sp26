public abstract class Hero : Character
{
  private double Xp;

  public Hero(string name, int maxHp, int speed, double defense, int stamina, double strength, int mana) : 
  base(name, maxHp, speed, defense, stamina, strength, mana)
    {
        Xp = 0;
        Lvl = 1;
    }

  /* Xp required to level up = C * L^2 
    C is the multipler and L is the level C can range from 10 - 100
    For a balanced game C could equal 40, then we can adjust the amount of Xp gained per interaction. 
  */

  public double GainXp(double amount)
    {
        Xp += amount;
        return Xp;
    }

    public virtual void LevelUp()
    {
        
    }

    public override Character ChooseTarget(List<Character> Enemies)
    {
        var livingTargets = Enemies.Where(t => t.IsAlive).ToList();
        if (livingTargets.Count == 0) return null;

        // need apropiate getter for name
        Console.WriteLine("Select a target:");
        for (int i = 0; i < livingTargets.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {livingTargets[i].Name}");
        }

        Console.Write("Enter number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= livingTargets.Count)
        {
            return livingTargets[index - 1];
        }

        Console.WriteLine("Invalid target selection! Forfeiting turn attack.");
        return null;
    }


    /*

    public override void Attack(int damage)
    {
        throw new NotImplementedException();
    }

    public override void TakeTurn(Character Target)
    {
        throw new NotImplementedException();
    }

*/

}