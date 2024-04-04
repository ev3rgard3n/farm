using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public void Set(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public string Load(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetString(key);
        }
        return null;
    }
}
