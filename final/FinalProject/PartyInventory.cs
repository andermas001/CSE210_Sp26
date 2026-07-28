public class PartyInventory
{
    public List<Item> Items {get;} = new List <Item> ();
    public int Gold {get; set;} = 50;

    public void AddItem (Item item)
    {
        Items.Add(item);
        Console.WriteLine($"🎒 Added [{item.Name}] to party inventory!");
    }
    public void DisplayInventory()
    {
        Console.WriteLine($"\n=== 🎒 PARTY INVENTORY (Gold: {Gold} 🪙) ===");
        if (Items.Count == 0)
        {
            Console.WriteLine("Your bag is currently empty.");
            return;
        }

        for(int i = 0; i< Items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Items[i].Name} ({Items[i].Type}) - {Items[i].ItemDescription}");
        }
    }

    public void UseItemMenu(List<Character> party)
    {
        if (Items.Count == 0)
        {
            Console.WriteLine("No items to use!");
            return;
        }
        DisplayInventory();
        Console.WriteLine("\nSelect item number to use (or 0 to cancel)");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Items.Count)
        {
            Item selectedItem = Items[choice -1];

            Console.WriteLine("\nSelect who to use it on:");
            for (int i = 0; i<party.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {party[i].Name} (HP: {party[i].Health}/{party[i].MaxHealth})");
            }
            Console.Write("Choice: ");
            if (int.TryParse(Console.ReadLine(), out int heroChoice) && heroChoice > 0 && heroChoice <= party.Count)
            {
                Character target = party[heroChoice - 1];
                selectedItem.Use(target);

                if (selectedItem.Type == ItemType.Consumable)
                {
                    Items.RemoveAt(choice -1);
                }
            }
        }
    }
}