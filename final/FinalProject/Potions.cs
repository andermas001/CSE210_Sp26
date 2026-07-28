public enum PotionType
{
    Health,
    Mana,
    Strength,
    Speed,
    ManaPower, 
    Invulnerability,
    Vulnerability, 
    Weakness,
    poison
}

public class Potions : Item
{
    public PotionType PotionType {get;}
    public int Magnitude {get;}
    public int Duration{get;}
    

    public Potions(string name, string description, PotionType type, int value, int magnitude = 0, int duration = 1) 
    : base (name, description, ItemType.Consumable, value)
    {
        PotionType = type;
        Magnitude = magnitude;
        Duration = duration;
    }

    public override void Use(Character user)
    {
        ApplyEffect(user);
    }

    public void ApplyEffect(Character target)
    {
        if (!target.IsAlive) return;

        switch (PotionType)
        {
            case PotionType.Health:
                target.RecievedHealing(Magnitude);
                break;
            case PotionType.Mana:
                    target.RefillMana(Magnitude);
                    break;

            case PotionType.Strength:
                    target.RecievedBuff(Magnitude, Duration);
                    break;
            case PotionType.Speed:
                    // target.ApplySpeedBuff(Magnitude, Duration);
                    break;
            case PotionType.Invulnerability:
                    // target.ApplyInvulnerability(Duration);
                    break;
            case PotionType.Vulnerability:
                    // target.ApplyVulnerability(Duration);
                    break;
            case PotionType.Weakness:
                // Applyweakness(Magnitude, Duration)
                break;
            case PotionType.poison:
                // ApplyPoison(Magnitude, Duration)
                break;
        }
    }
}