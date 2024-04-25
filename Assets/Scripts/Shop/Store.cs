using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Store : MonoBehaviour
{
    
    public static List<Item> StoreItems = new();
    private List<StoreSlot> _storeSlots = new();

    private void Start()
    {
        _storeSlots = GetComponentsInChildren<StoreSlot>().ToList();
        GenerateAllItems(); 
        DummyMethod();
    }

    private void DummyMethod()
    {
        int i = 0;
        foreach (StoreSlot slot in _storeSlots)
        {
            slot.FillSlot(i);
            i++;
        }
    }


    private void GenerateAllItems()
    {

        StoreItems.Add(new Item("carrot", "Food/carrot", Item.TYPEFOOD, 12, 10, 1, 5f));
        StoreItems.Add(new Item("eggplant", "Food/carrot", Item.TYPEFOOD, 5, 10, 2, 5f));
        StoreItems.Add(new Item("pumpkin", "Food/carrot", Item.TYPEFOOD, 11, 8, 1, 5f));
        StoreItems.Add(new Item("carrot", "Food/carrot", Item.TYPEFOOD, 3, 10, 1, 5f));
        StoreItems.Add(new Item("Axe", "Tools/Axe", Item.TYPEAXE, 0, 0, 0, 0f));
        StoreItems.Add(Player.SetEmptyValueToItem());
        StoreItems.Add(Player.SetEmptyValueToItem());
        StoreItems.Add(Player.SetEmptyValueToItem());

    }


    private IEnumerator UpdateStore()
    {
        yield return new WaitForSeconds(1);

    }
}
