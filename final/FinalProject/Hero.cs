public abstract class Hero : Character
{
  private int Xp;

  public Hero(string name, int maxHp, int speed, double defense, int stamina, double strength, int mana) : 
  base(name, maxHp, speed, defense, stamina, strength, mana)
    {
        Xp = 0;
        _lvl = 1;
    }

  /* Xp required to level up = C * L^2 
    C is the multipler and L is the level C can range from 10 - 100
    For a balanced game C could equal 40, then we can adjust the amount of Xp gained per interaction. 
  */

  public int GainXp(int amount)
    {
        Xp += amount;
        return Xp;
    }

    public virtual void LevelUp()
    {
        
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