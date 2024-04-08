using System.Collections;
using UnityEngine;

public class Crop : MonoBehaviour
{
    private Item cropItem;
    private SpriteRenderer _seedSprite;
    private SpriteRenderer _productSprite;
    private SpriteRenderer _cropSprite;
    private GameObject _player;

    private int _step = 0;
    private readonly int  _stepsEmpty = 0;
    private readonly int _stepsGrows = 1;
    private readonly int _stepsReady = 2;
    private readonly int _stepsPlow = 3;
    private bool _readyForAction;


    private void Awake()
    {
        _cropSprite = GetComponent<SpriteRenderer>();
        _seedSprite = GetComponentsInChildren<SpriteRenderer>()[2];
        _productSprite = GetComponentsInChildren<SpriteRenderer>()[1];

        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnMouseDown()
    {

        Item item = Player.GetHandItem();

        if (_readyForAction)
        {
            if (_step == _stepsEmpty)
            {
                if (item.type == Item.TYPEFOOD)
                {
                    _step = _stepsGrows;
                    cropItem = item;
                    _seedSprite.sprite = Resources.Load<Sprite>("Food/seeds");
                    StartCoroutine(Grow());
                }
            }
            else if (_step == _stepsReady)
            {
                _productSprite.sprite = Resources.Load<Sprite>("Food/empty");
                _seedSprite.sprite = Resources.Load<Sprite>("Food/extraDirt");
                item.count = 2;
                Player.CheckIfItemExist(item);
            }
        }

    }

    private IEnumerator Grow()
    {
        yield return new WaitForSeconds(cropItem.timeToGrow);
        _seedSprite.sprite = Resources.Load<Sprite>("Food/empty");
        _productSprite.sprite = Resources.Load<Sprite>(cropItem.imageUrl);
        _step = _stepsReady;
    }

    private void FixedUpdate()
    {
        if (_step != _stepsGrows)
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < 0.2f)
            {
                _readyForAction = true;
                _cropSprite.sprite = Resources.Load<Sprite>("Food/cropSelected");

            }
            else
            {
                _readyForAction = false;
                _cropSprite.sprite = Resources.Load<Sprite>("Food/crop");

            }
        }
        else
        {
            _cropSprite.sprite = Resources.Load<Sprite>("Food/crop");
        }
    }
}
