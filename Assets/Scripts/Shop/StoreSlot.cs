using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreSlot : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    private int id;
    private Image _slotImage;
    private Image _itemImage;
    private TextMeshProUGUI _priceSlot;
    private Wallet _wallet;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { BuyItem(); });
        _wallet = FindObjectOfType<Wallet>();
        if (_wallet == null)
        {
            Debug.LogError("Wallet object not found in the scene.");
        }
    }

    public void FillSlot(int id)
    {
        this.id = id;

        _slotImage = GetComponent<Image>();
        Image[] images = GetComponentsInChildren<Image>();
        _priceSlot = GetComponentInChildren<TextMeshProUGUI>();
        Item slot = Store.StoreItems[id];

        if (images.Length > 1)
        {
            _itemImage = images[1];
        }
        else
        {
            _itemImage = null;
        }

        _priceSlot.text = $"{slot.price}$";

        if (_itemImage != null)
        {
            _itemImage.sprite = Resources.Load<Sprite>(slot.imageUrl);
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

    private void BuyItem()
    {

        Item item = Store.StoreItems[this.id];

        Debug.Log(item);
        Debug.Log(_wallet.TryToSpend(item.price));

        if (_wallet.TryToSpend(item.price))
        {
            Player.CheckIfItemExist(item);
            Store.StoreItems.RemoveAt(this.id);
        }
    }
}