using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OrderSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Image _slotImage;
    private Image _itemImage;
    private TextMeshProUGUI _countItem;
    private TextMeshProUGUI _awards;

    private int id;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { GetAwards(); });  
    }
    public void FillOrder(int id)
    {
        this.id = id;

        _slotImage = GetComponent<Image>();

        _itemImage = GetComponentsInChildren<Image>()[1];
        _countItem = GetComponentsInChildren<TextMeshProUGUI>()[1];
        _awards = GetComponentsInChildren<TextMeshProUGUI>()[0];

        Item item = Orders.ItemForAwards[this.id];

        if (item.count > 0)
        {
            _countItem.text = $"x{item.count}";
            _awards.text = $"{item.price + 10}";
        }
        else
        {
            _countItem.text = "";
            _awards.text = "";
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

    private void GetAwards()
    {
        Debug.Log(231);
    }
}
