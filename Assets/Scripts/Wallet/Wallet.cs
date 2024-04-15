using System;
using System.Diagnostics.Tracing;
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


    public void MoneyAddTest()
    {
        AddMoney(10);
    }

    public void MoneySpendTest()
    {
        TryToSpend(10);
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
