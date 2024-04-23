using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Text _amountText;
    [SerializeField] private Wallet _wallet;
    private void OnEnable()
    {
        _wallet.AmountChanged += DisplayAmount;
    }

    private void OnDisable()
    {
        _wallet.AmountChanged -= DisplayAmount;
    }

    public void DisplayAmount()
    {
        float money = _wallet.Money;
        _amountText.text = money.ToString() + "$";
    }
}
