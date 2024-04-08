using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Diagnostics;

public class Player : MonoBehaviour
{
    public static List<Item> player_items = new ();

    private void Start()
    {
        Item item = new("carrot", "Food/carrot",Item.TYPEFOOD, 3, 10, 1, 5f);
        player_items.Add(item);
    }

    public static void CheckIfItemExist(Item item)
    {
        var existingItem = player_items.FirstOrDefault(i => i.name == item.name);

        if (existingItem != null)
        {
            existingItem.count += item.count;
        }
        else
        {
            /*player_items.Add(item);*/
            addItemToInventory(item);
        }
        
    }

    private static void addItemToInventory(Item item)
    { 
        var added = player_items.FirstOrDefault(i => i.name == "empty");

        if (added != null)
            added = item;
        else
            player_items.Add (item);

    }

    public static Item GetHandItem()
    {
        string name = player_items[0].name;
        string imageUrl = player_items[0].imageUrl;
        int type = player_items[0].type;
        int count = player_items[0].count;
        int price = player_items[0].price;
        int lvlWhenUnlock = player_items[0].lvlWhenUnlock;
        float timeToGrow = player_items[0].timeToGrow;
        return new Item(name, imageUrl, type, count, price, lvlWhenUnlock, timeToGrow);
    }
}
