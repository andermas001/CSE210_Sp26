public abstract class Hero : Character
{
  private int Xp;

  public Hero(string name, int maxHp, int speed, int defense, int stamina, int strength) : base(name, maxHp, speed, defense, stamina, strength)
    {
        Xp = 0;
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

    public void levelUp()
    {
        
    }

    public override void Attack(int damage)
    {
        throw new NotImplementedException();
    }

    public override void TakeTurn(Character Target)
    {
        throw new NotImplementedException();
    }



}