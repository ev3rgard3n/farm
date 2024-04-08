using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Image _slotImage;
    private Image _itemImage;
    private Text _countItems;

    public void FillSlot(Item item)
    {
        _slotImage = GetComponent<Image>();
        _itemImage = GetComponentsInChildren<Image>()[1];
        _countItems = GetComponentInChildren<Text>();

        if (item.count > 0 )
        {
            _countItems.text = $"x{item.count}";
        }
        else
        {
            _countItems.text = "";
        }
        _itemImage.sprite = Resources.Load<Sprite>(item.imageUrl);

    }
}
