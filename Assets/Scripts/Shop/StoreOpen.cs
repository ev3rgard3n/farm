using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StoreOpen : MonoBehaviour
{

    [SerializeField] private GameObject _storePrefab;


    private GameObject _player; 
    public GameObject _store;
    public bool StoreIsOpened = false;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void ChancheSprite()
    {

    }

    public void OpenStore()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < 0.4f)
        {
            if (StoreIsOpened)
            {
                Destroy(_store);
                StoreIsOpened = false;
            }
            else
            {
                _store = Instantiate(_storePrefab);


                _store.transform.SetParent(gameObject.transform);
                _store.GetComponent<RectTransform>().offsetMax = new Vector2(300, 30);
                _store.GetComponent<RectTransform>().offsetMin = new Vector2(-300, -50);
                _store.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                StoreIsOpened = true;
            }
        }
    }
    
    private void OnMouseDown()
    {
        OpenStore();
    }
}