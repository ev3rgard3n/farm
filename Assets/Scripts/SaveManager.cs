using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }

    private static BinaryFormatter _binaryFormatter = new();
    private static string _inventoryPath;
    private static string _moneyPath;
    private static string _playerPositionPath;


    private static Wallet _wallet;
    private static GameObject _player;

    private void Awake()
    {
        _wallet = FindObjectOfType<Wallet>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _moneyPath = $"{Application.persistentDataPath}/money.path";
        _inventoryPath = $"{Application.persistentDataPath}/inventory.path";
        _playerPositionPath = $"{Application.persistentDataPath}/player.path";
    }

    private IEnumerator SaveTimer()
    {
        yield return new WaitForSeconds(5);
        SaveAllParams();
    }

    public static void SaveAllParams()
    {
        Debug.Log("SaveManager");
        SaveInventory();
        SaveMoney();
    } 

    private static void SaveInventory()
    {
        FileStream stream = new(_inventoryPath, FileMode.Create);
        _binaryFormatter.Serialize(stream, Player.player_items);
        stream.Close();
    }
    
    private static void SaveMoney()
    {
        FileStream stream = new(_moneyPath, FileMode.Create);
        _binaryFormatter.Serialize(stream, _wallet.Money);
        stream.Close();
    }

    public static List<Item> LoadInventory()
    {
        if (File.Exists(_inventoryPath))
        {
            FileStream stream = new( _inventoryPath, FileMode.Open);
            List<Item> items = (List<Item>) _binaryFormatter.Deserialize(stream);
            stream.Close();
            return items;
        } else
        {
            List<Item> startItems = new List<Item>();
            startItems.Add(Player.SetEmptyValueToItem());
            startItems.Add(new Item("carrot", "Food/carrot", Item.TYPEFOOD, 1, 10, 1, 5f));
            startItems.Add(new Item("Axe", "Tools/Axe", Item.TYPEAXE, 0, 0, 0, 0f));
            startItems.Add(new Item("Hoe", "Tools/Hoe", Item.TYPEHOE, 0, 0, 0, 0f));
            
            return startItems;
        }
    }

    public static int LoadMoney()
    {
        if (File.Exists(_moneyPath))
        {
            FileStream stream = new(_moneyPath, FileMode.Open);
            int money = (int) _binaryFormatter.Deserialize(stream);
            stream.Close();
            return money;
        }
        else
        {
            return 100;
        }
    }
    

    public static void ClearAllData()
    {
        if (File.Exists(_moneyPath)) File.Delete(_moneyPath);
        if (File.Exists(_inventoryPath)) File.Delete(_inventoryPath);
        if (File.Exists(_playerPositionPath)) File.Delete(_playerPositionPath);
    }
}
