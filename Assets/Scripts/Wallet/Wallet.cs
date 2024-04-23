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
        SaveManager.Set("Money", Money.ToString());
    }

    private void LoadBalance()
    {
        string loadedMoney = SaveManager.Load("Money");

        Debug.Log(loadedMoney);

        Money = string.IsNullOrEmpty(loadedMoney) ? 10 : int.Parse(loadedMoney);
        AmountChanged?.Invoke();
    }
    public void AddMoney(int amount)
    {
        if (amount >= 0) Money += amount;

        SaveManager.Set("Money", Money.ToString());

        AmountChanged?.Invoke();
    }

    public bool TryToSpend(int price) 
    {
        Debug.Log($"Money {Money}");
        Debug.Log($"price {price}");

        if (price <= Money)
        {
            Money -= price;
            SaveManager.Set("Money", Money.ToString());
            AmountChanged?.Invoke();
            return true;
        }
        return false;
    }
}
