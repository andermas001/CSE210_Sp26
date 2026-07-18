class DungeonManager
{
   private GameManager _game;
   private int _currentFloor = 1;
   private int _roomsCleared = 0;

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
         Console.WriteLine("1. Open the next door (Advance & Start Encounter)");
         Console.WriteLine("2. Check Party Status (Heal / View Stats)");
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

      bool victory = _game.TriggerRoomEncounter(_currentFloor, isBossRoom);

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