class DungeonManager
{
   private GameManager _game;
   private int _currentFloor = 1;
   private int _roomsCleared = 0;
   private static Random _rand = new Random();

   private static readonly string[] _roomDescriptions = 
   {
      "You step through a heavy iron door into a damp corridor and cross paths with {0}!",
      "Your companions cautiously enter a strange, dimly lit chamber. Suddenly, {0} lunges from the shadows!",
      "The air grows cold as you navigate deeper into the dungeon. Blocking your path stands {0}!",
      "As your party clears away thick cobwebs in the ruins, you catch the scent of danger and spot {0}!",
      "A sudden noise echoes through the hall. Your heroes draw their weapons as they lock eyes with {0}!",
      "The flickering torchlight reveals a moss-covered room where {0} patiently waits for you!"
   };

   private string GetRandomRoomDescription(string encounterDetails)
    {
         if (string.IsNullOrEmpty(encounterDetails))
         {  
            encounterDetails = "a group of dangerous monsters";
         }
         int index = _rand.Next(_roomDescriptions.Length);
         string template = _roomDescriptions[index];

         // 3. Use standard string replacement instead of Format to avoid bracket crashes
         return template.Replace("{0}", encounterDetails);
    }

   public DungeonManager(GameManager game)
   {
      _game = game;
   }

   public void Explore()
   {
      bool exploring = true;

      while (exploring && _game.IsPartyAlive())
      {
         Console.Clear();
         Console.WriteLine($"====================================");
         Console.WriteLine($"   🏰 DUNGEON FLOOR: {_currentFloor} | ROOMS: {_roomsCleared} 🏰");
         Console.WriteLine($"====================================");
         Console.WriteLine("Your party rests in a dim corridor. What do you want to do?");
         Console.WriteLine("1. Continue Exploring (Advance & Start Encounter)");
         Console.WriteLine("2. Check Party Status (View Stats)");
         Console.WriteLine("3. Retreat to Town (Keep current XP and Gold, Reset Floor)");
         Console.Write("\nChoose an option: ");

         string choice = Console.ReadLine();

         switch (choice)
         {
            case "1":
               AdvanceToNextRoom();
               break;
            
            case "2":
               _game.ShowPartyStatus();
               break;

            case "3":
               exploring = HandleRetreat();
               break;
         }
      }
   }

   private void AdvanceToNextRoom()
   {
      _roomsCleared ++ ;
      bool isBossRoom = (_roomsCleared % 5 ==0);

      bool victory = _game.TriggerRoomEncounter(_currentFloor, isBossRoom, text => GetRandomRoomDescription(text));

      if (victory)
      {
        Console.WriteLine("\nPress Enter to continue deeper into the dungeon...");
        Console.ReadLine();

        if (isBossRoom)
         {
            _currentFloor ++;
            Console.WriteLine($"✨ The path opens! You've descended to Floor {_currentFloor}! Enemies are growing stronger... ✨");
            Console.ReadLine();
         }
      }
      else
      {
        Console.WriteLine("You have fallen to your enemies...");
      }
   }

   private bool HandleRetreat()
   {
      Console.WriteLine("\nAre you sure you want to run back to town?");
      Console.WriteLine("You will preserve your hard-earned XP, but dungeon progress resets.");
      Console.Write("(y/n): ");
    
      if (Console.ReadLine().ToLower() == "y")
      {
         Console.WriteLine("\n🏃 Your party flees the dungeon and rests at the Inn. HP and Mana restored!");
         _game.FullyHealParty(); // Helper to restore private _currentHp to MaxHp
         _roomsCleared = 0;
         _currentFloor = 1;
         Console.ReadLine();
         return true; // Keeps exploration loop active, but safely back at the entrance hub
     }
      return true;
   }
}