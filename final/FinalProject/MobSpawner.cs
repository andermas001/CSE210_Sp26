using System.Security.Cryptography.X509Certificates;

public static class MobSpawner
{
    private static Random _rand = new Random();

    // mob names
    private static readonly string[] _goblinNames = { "Skitch", "Grizzle", "Sneak", "Drool", "Ratsnack", "Pinch" };
    private static readonly string[] _orcNames = { "Grom", "Thorg", "Garrosh", "Urgok", "Kargath", "Brox" };
    private static readonly string[] _golemNames = { "Granite", "Obsidian", "Rubble", "Ironclad", "Boudler", "Monolith" };
    private static readonly string[] _wolfNames = { "Frostbite", "Shadow", "Gnasher", "Silverback", "Bloodhound", "Fang" };
    private static readonly string[] _bossNames = { "Malakor the Undying", "Gorgoroth the World-Breaker", "Xylar the Defiler" };

    private static string GetRandName(string[] namePool)
    {
        int index = _rand.Next(namePool.Length);
        return namePool[index];
    }

    public static (List<Monster> enemies, string encounterDescription) GenerateEncounter(int floorLvl)
    {
        List<Monster> encounterList = new List<Monster>();

        int encounterType = _rand.Next(3);

        int minLvl = Math.Max(1, floorLvl - 3);
        int maxLvl = floorLvl +1;
        string description = "";

        switch (encounterType)
        {
            case 0:
                var orc = new Orc($"{GetRandName(_orcNames)} (Orc)", _rand.Next(minLvl, maxLvl));
                var gob1 = new Goblin($"{GetRandName(_goblinNames)} (goblin)", _rand.Next(minLvl, maxLvl));
                var gob2 = new Goblin($"{GetRandName(_goblinNames)} (goblin)", _rand.Next(minLvl, maxLvl));

                encounterList.Add(orc);
                encounterList.Add(gob1);
                encounterList.Add(gob2);

                description = $"an aggressive raiding party led by {orc.Name}";
                break;

            case 1:
                int packSize = _rand.Next(2, 5);
                string alphaName = "";
                int currentAlphaLvl = 0;
                for(int i = 0;  i < packSize; i++)
                {
                    var wolf = new Wolf($"{GetRandName(_wolfNames)}, (Wolf)", _rand.Next(minLvl, maxLvl));
                    if (wolf.Lvl > currentAlphaLvl)
                    {
                        alphaName = wolf.Name;
                        currentAlphaLvl = wolf.Lvl;
                    }
                    encounterList.Add(wolf);
                }
                description = $"a feral pack of {packSize} wolves trailed by the Alpha {alphaName}";
                break;

            case 2:
                var golem = new Golem($"{GetRandName(_golemNames)} (golem)", _rand.Next(minLvl, maxLvl));
                encounterList.Add(golem);
                if (_rand.NextDouble() > 0.5)
                {
                    var goblin = new Goblin($"{GetRandName(_goblinNames)} (goblin)", minLvl);
                    encounterList.Add(goblin);
                }
                break;             
        }
        return (encounterList, description);
    }


    public static (List<Monster> enemies, string encounterDescription) GenerateBossEncounter(int floorLvl)
    {
        int bossLvl = floorLvl + _rand.Next(1, 3);
        var boss = new Boss(GetRandName(_bossNames), bossLvl);
        return (new List<Monster> { boss }, $"⚠️ THE DUNGEON OVERLORD: {boss.Name} ⚠️");
    }

}