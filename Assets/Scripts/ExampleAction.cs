using System;
using UnityEngine;

public class ExampleAction : MonoBehaviour
{
    public event Action MoneyChanged;
    public event Action<int> MoneyAdd;
    public event Action LVLChanged;
}
