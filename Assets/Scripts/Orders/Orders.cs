using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Orders : MonoBehaviour
{
    public static List<Item> ItemForAwards = new();

    private List<OrderSlot> _orders;

    private void Start()
    {
        GenerateItemForAdwards();

        _orders = GetComponentsInChildren<OrderSlot>().ToList();

        int i = 0;
        foreach (OrderSlot item in _orders)
        {
            item.FillOrder(i);
            i++;
        }
    }

    private void GenerateItemForAdwards()
    {
        ItemForAwards.Add(new Item("carrot", "Food/carrot", Item.TYPEFOOD, 12, 10, 1, 5f));
        ItemForAwards.Add(new Item("eggplant", "Food/carrot", Item.TYPEFOOD, 5, 10, 2, 5f));
        ItemForAwards.Add(new Item("pumpkin", "Food/carrot", Item.TYPEFOOD, 11, 8, 1, 5f));
        ItemForAwards.Add(new Item("carrot", "Food/carrot", Item.TYPEFOOD, 3, 10, 1, 5f));
        ItemForAwards.Add(new Item("Axe", "Tools/Axe", Item.TYPEAXE, 0, 0, 0, 0f));
        ItemForAwards.Add(Player.SetEmptyValueToItem());
        ItemForAwards.Add(Player.SetEmptyValueToItem());
        ItemForAwards.Add(Player.SetEmptyValueToItem());
        ItemForAwards.Add(Player.SetEmptyValueToItem());
        ItemForAwards.Add(Player.SetEmptyValueToItem());
        ItemForAwards.Add(Player.SetEmptyValueToItem());
        ItemForAwards.Add(Player.SetEmptyValueToItem());
    }
}
