using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    private List<Slot> _slots = new ();
    public static Slot InventorySelected = null;

    private void Start()
    {
        _slots = GetComponentsInChildren<Slot>().ToList();

        int i = 0;

        foreach (Slot slot in _slots)
        {
            slot.FillSlot(i);
            i++;
        }
    }

}
