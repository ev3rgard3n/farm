using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private Image _slotImage;
    private Image _itemImage;
    private Text _countItems;

    private int id;

    private void Start()
    {

        GetComponent<Button>().onClick.AddListener(delegate { Click(); });
    }
    public void FillSlot(int id)
    {
        this.id = id;
        Item item = Player.player_items[id];

        _slotImage = GetComponent<Image>();
        Image[] images = GetComponentsInChildren<Image>();
        if (images.Length > 1)
        {
            _itemImage = images[1];
        }
        else
        {
            // Handle the case where there is no second image child
            _itemImage = null;
        }
        _countItems = GetComponentInChildren<Text>();

        if (item.count > 0)
        {
            _countItems.text = $"x{item.count}";
        }
        else
        {
            _countItems.text = "";
        }
        if (_itemImage != null)
        {
            _itemImage.sprite = Resources.Load<Sprite>(item.imageUrl);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _slotImage.sprite = Resources.Load<Sprite>("Asset for olymp/panel");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _slotImage.sprite = Resources.Load<Sprite>("Asset for olymp/placeHolder");
    }
    public void Click()
    {
        if (Inventory.InventorySelected == null) 
        {
            Debug.Log(1);
            _slotImage.sprite = Resources.Load<Sprite>("Asset for olymp/placeHolderSelected");
            Inventory.InventorySelected = this;
        } 
        else if (Inventory.InventorySelected != this) 
        {
            Item item = Player.player_items[Inventory.InventorySelected.id];
            Player.player_items[Inventory.InventorySelected.id] = Player.player_items[id];
            Player.player_items[id] = item;

            Inventory.InventorySelected.FillSlot(Inventory.InventorySelected.id);
            FillSlot(id);

            Inventory.InventorySelected = null;
        }

    }


}
