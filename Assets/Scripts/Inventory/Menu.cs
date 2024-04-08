using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPrefab;

    private bool InventoryOpened = false;
    private GameObject _inventory;

    public void OpenInventory()
    {
        if (InventoryOpened)
        {
            Destroy(_inventory);
            InventoryOpened = false;
        }
        else
        {
            _inventory = Instantiate(_inventoryPrefab);
            _inventory.transform.SetParent(gameObject.transform);
            _inventory.GetComponent<RectTransform>().offsetMin = new Vector2(150, 30);
            _inventory.GetComponent<RectTransform>().offsetMax = new Vector2(-150, -50);
            _inventory.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            InventoryOpened = true;
        }
    }
}
