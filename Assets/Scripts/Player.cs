using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Diagnostics;
using System;

public class Player : MonoBehaviour
{
    public int Level { get; private set; } = 0;
    [SerializeField] private int _emptyItemCountDefault=16;
    public static List<Item> player_items = new ();


    public event Action LevelChanged;
    

    public void LevelPlus1()
    {
        Level += 1;

        LevelChanged?.Invoke();
    }
    private void Start()
    {
        player_items = SaveManager.LoadInventory();

        for (int i = 0; i <= _emptyItemCountDefault; i++)
        {
            if (player_items.Count >= 16) 
            {
                break;
            }
            player_items.Add(SetEmptyValueToItem());
        }

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
            addItemToInventory(item);
        }
        
    }

    private static void addItemToInventory(Item item)
    {
        var added = player_items.FirstOrDefault(i => i.name == "empty");

        if (added != null)
            player_items[player_items.IndexOf(added)] = item;
        else
            player_items.Add(item);
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

    public static Item SetEmptyValueToItem()
    {
        return new Item("empty", "Food/empty", 0, 0, 0, 0, 0);
    }

    public static void RemoveItem()
    {
        if (player_items[0].count == 1)
        {
            player_items[0] = SetEmptyValueToItem();
        }
        else
        {
            player_items[0].count -= 1;
        }
    }
}
