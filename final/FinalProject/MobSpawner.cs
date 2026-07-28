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
    private static readonly string[] _skeletonNames = { "Rattles", "Clatter", "Bones", "Dusty", "Drybones", "Grind" };
    private static readonly string[] _knightNames = { "Sir Valerius", "Lord Malice", "Ironclad", "Dreadguard", "Coldsteel" };
    private static readonly string[] _necromancerNames = { "Malakor", "Vorak", "Zul'tan", "Morbius", "Necros", "Vesper" };
    private static readonly string[] _slimeNames = { "Gooey", "Acidic", "Viscous", "Glob", "Slick", "Sludge" };
    private static readonly string[] _banditNames = { "Sly", "Viper", "Rogue", "Ghost", "Shank", "Fingerjack" };
    private static readonly string[] _direwolfNames = { "Fenrir", "Grimfang", "Ashen", "Bloodjaw", "Blight" };
    private static readonly string[] _undeadMinionNames = { "Crawling Husk", "Rotting Thrall", "Decayed Shambler", "Bone Fragment" };

    private static string GetRandName(string[] namePool)
    {
        int index = _rand.Next(namePool.Length);
        return namePool[index];
    }

    public static (List<Monster> enemies, string encounterDescription) GenerateEncounter(int floorLvl)
    {
        List<Monster> encounterList = new List<Monster>();

        int encounterType = _rand.Next(8);

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

                description = $"an aggressive raiding party led by {orc.Name} | Lvl:{orc.Lvl}";
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
                description = $"a feral pack of {packSize} wolves trailed by the Alpha {alphaName}| Lvl:{currentAlphaLvl}";
                break;

            case 2:
                var golem = new Golem($"{GetRandName(_golemNames)} (golem)", _rand.Next(minLvl, maxLvl));
                encounterList.Add(golem);
                if (_rand.NextDouble() > 0.5)
                {
                    var goblin = new Goblin($"{GetRandName(_goblinNames)} (goblin)", minLvl);
                    encounterList.Add(goblin);
                }
                description = $"a fallen ruin with {golem.Name} | Lvl:{golem.Lvl} Rising from the debree";
                break;

            case 3: // Graveyard Ritual Encounter
                    var necro = new Necromancer($"{GetRandName(_necromancerNames)} (Necromancer)", _rand.Next(minLvl, maxLvl));
                    var skel1 = new Skeleton($"{GetRandName(_skeletonNames)} (Skeleton)", _rand.Next(minLvl, maxLvl));
                    var minion = new UndeadMinion($"{GetRandName(_undeadMinionNames)}", minLvl);

                    encounterList.Add(necro);
                    encounterList.Add(skel1);
                    encounterList.Add(minion);

                    description = $"A dark altar where {necro.Name} | Lvl:{necro.Lvl} channels necrotic power over his undead thralls!";
                    break;

                case 4: // Highway Bandit Ambush
                    var banditLeader = new Bandit($"{GetRandName(_banditNames)} (Bandit Leader)", _rand.Next(minLvl, maxLvl));
                    var direwolf = new Direwolf($"{GetRandName(_direwolfNames)} (Direwolf)", _rand.Next(minLvl, maxLvl));
                    
                    encounterList.Add(banditLeader);
                    encounterList.Add(direwolf);

                    if (_rand.NextDouble() > 0.4)
                    {
                        var lackey = new Bandit($"{GetRandName(_banditNames)} (Bandit Lackey)", minLvl);
                        encounterList.Add(lackey);
                    }

                    description = $"A shadowy corridor where {banditLeader.Name} | Lvl:{banditLeader.Lvl} and a vicious Direwolf spring an ambush!";
                    break;

                case 5: // Corrosive Slime Pit
                    int slimeCount = _rand.Next(2, 4);
                    for (int i = 0; i < slimeCount; i++)
                    {
                        var slime = new Slime($"{GetRandName(_slimeNames)} (Slime)", _rand.Next(minLvl, maxLvl));
                        encounterList.Add(slime);
                    }
                    description = $"A damp cavern floor melting beneath a puddle of {slimeCount} acidic Slimes!";
                    break;

                case 6: // Undead Vanguard (Skeletons & Skeleton Knight)
                    var knight = new SkeletonKnight($"{GetRandName(_knightNames)} (Skeleton Knight)", _rand.Next(minLvl, maxLvl));
                    var warrior = new Skeleton($"{GetRandName(_skeletonNames)} (Skeleton)", _rand.Next(minLvl, maxLvl));

                    if (_rand.NextDouble() > 0.4)
                    {
                        var Archer = new SkeletonArcher($"{GetRandName(_skeletonNames)} (Skeleton Archer)", minLvl);
                        encounterList.Add(Archer);
                    }
                    encounterList.Add(knight);
                    encounterList.Add(warrior);

                    description = $"An ancient crypt guard led by the towering {knight.Name} | Lvl:{knight.Lvl}";
                    break;

                case 7: // Direwolf Pack
                    int wolfPackSize = _rand.Next(2, 4);
                    for (int i = 0; i < wolfPackSize; i++)
                    {
                        var dWolf = new Direwolf($"{GetRandName(_direwolfNames)} (Direwolf)", _rand.Next(minLvl, maxLvl));
                        encounterList.Add(dWolf);
                    }
                    description = $"A snarling pack of {wolfPackSize} Direwolves prowling the dungeon corridor!";
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