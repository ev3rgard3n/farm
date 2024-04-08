using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    private List<Slot> _slots = new ();

    private void Start()
    {
        _slots = GetComponentsInChildren<Slot>().ToList();

        int i = 0;

        foreach (Slot slot in _slots)
        {
            slot.FillSlot(Player.player_items[i]);
            i++;
        }
    }
}
