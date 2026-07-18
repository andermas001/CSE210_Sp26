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

    public static List<Monster> GenerateEncounter(int floorLvl)
    {
        List<Monster> encounterList = new List<Monster>();

        int encounterType = _rand.Next(3);

        int minLvl = Math.Max(1, floorLvl - 3);
        int maxLvl = floorLvl +1;

        switch (encounterType)
        {
            case 0:
                encounterList.Add(new Orc($"{GetRandName(_orcNames)} (Orc)", _rand.Next(minLvl, maxLvl)));
                encounterList.Add(new Goblin($"{GetRandName(_goblinNames)} (goblin)", _rand.Next(minLvl, maxLvl)));
                encounterList.Add(new Goblin($"{GetRandName(_goblinNames)} (goblin)", _rand.Next(minLvl, maxLvl)));
                break;

            case 1:
                int packSize = _rand.Next(2, 5);
                for(int i = 0;  i < packSize; i++)
                {
                    encounterList.Add(new Wolf($"{GetRandName(_wolfNames)}, (Wolf)", _rand.Next(minLvl, maxLvl)));
                }
                break;

            case 2:
                encounterList.Add(new Golem($"{GetRandName(_golemNames)} (golem)", _rand.Next(minLvl, maxLvl)));
                if (_rand.NextDouble() > 0.5)
                    encounterList.Add(new Goblin($"{GetRandName(_goblinNames)} (goblin)", minLvl));
                break;             
        }

        return encounterList;
    }


    public static List<Monster> GenerateBossEncounter(int floorLvl)
    {
        return new List<Monster> { new Boss($"{GetRandName(_bossNames)}",  floorLvl +2)};
    }

}