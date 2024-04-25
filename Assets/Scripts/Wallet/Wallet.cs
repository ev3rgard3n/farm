using System;
using Unity.VisualScripting;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Money {  get; private set; }
    public event Action AmountChanged;


    private void Start()
    {
        LoadBalance();
    }

    public void AddMoneyTest()
    {
        Money += 10;
        AmountChanged?.Invoke();
        SaveManager.SaveAllParams();
    }

    private void LoadBalance()
    { 
        Money = SaveManager.LoadMoney();
        AmountChanged?.Invoke();
    }
    public void AddMoney(int amount)
    {
        if (amount >= 0) Money += amount;

        SaveManager.SaveAllParams();

        AmountChanged?.Invoke();
    }

    public bool TryToSpend(int price) 
    {
        Debug.Log($"Money {Money}");
        Debug.Log($"price {price}");

        if (price <= Money)
        {
            Money -= price;
            SaveManager.SaveAllParams();
            AmountChanged?.Invoke();
            return true;
        }
        return false;
    }
}
