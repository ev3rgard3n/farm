using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Говнокод  Turn On
public class DeskOpen : MonoBehaviour
{

    [SerializeField] private GameObject _deskPrefab;

    public GameObject _desk;
    public bool _deskOpened = false;
    
    private GameObject _player;
    private SpriteRenderer _deskSprite;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _deskSprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, _player.transform.position) < 0.3f)
        {
            _deskSprite.sprite = Resources.Load<Sprite>("Desk/deskSelected");
        }
        else
        {
            _deskSprite.sprite = Resources.Load<Sprite>("Desk/desk");
        }
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(this.transform.position, _player.transform.position) < 0.3f)
        {
            if (_deskOpened)
            {
                Destroy(_desk);
                _deskOpened = false;
            }
            else
            {
                _desk = Instantiate(_deskPrefab);
                _desk.transform.SetParent(gameObject.transform);
                _desk.GetComponent<RectTransform>().offsetMin = new Vector2(150, 30);
                _desk.GetComponent<RectTransform>().offsetMax = new Vector2(-150, -50);
                _desk.GetComponent<RectTransform>().localScale = Vector3.one;

                _deskOpened = true;

            }
        }
    }

        
}
