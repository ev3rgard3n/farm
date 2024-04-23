using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPrefab;


    private bool InventoryOpened = false;

    private GameObject _inventory;
    private StoreOpen _storeOpen;
    private DeskOpen _deskOpen;

    private void Start()
    {
        _storeOpen = FindObjectOfType<StoreOpen>();
        _deskOpen = FindObjectOfType<DeskOpen>();

    }

    public void OpenInventory()
    {
        if (InventoryOpened)
        {
            Destroy(_inventory);
            InventoryOpened = false;
        }
        else
        {
            if (_storeOpen.StoreIsOpened) Destroy(_storeOpen._store);
            if (_deskOpen._deskOpened) Destroy(_deskOpen._desk); 

            _inventory = Instantiate(_inventoryPrefab);
            _inventory.transform.SetParent(gameObject.transform);
            _inventory.GetComponent<RectTransform>().offsetMin = new Vector2(150, 30);
            _inventory.GetComponent<RectTransform>().offsetMax = new Vector2(-150, -50);
            _inventory.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            InventoryOpened = true;
        }
    }
    
}
