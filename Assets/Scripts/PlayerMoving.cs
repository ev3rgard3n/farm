using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Sprite _mrFront, _mrBack, _mrLeft, _mrRight;

    private Vector2 _position;
    private Rigidbody2D _playerRigidbody;
    private SpriteRenderer _playerSprite;

    public SaveManager SaveManager;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerSprite = GetComponent<SpriteRenderer>();

        ChangeSprite(_mrFront);

    }

    private void ChangeSprite(Sprite sprite)
    {
        _playerSprite.sprite = sprite;
    }

    private void Update()
    {
        _position.x = Input.GetAxis("Horizontal");
        _position.y = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        if (_position.x > 0)
            ChangeSprite(_mrRight);
        else if (_position.x < 0)
            ChangeSprite(_mrLeft);
        else if (_position.y > 0)
            ChangeSprite(_mrBack);
        else if (_position.y >= 0)
            ChangeSprite(_mrFront);
        _playerRigidbody.MovePosition(_playerRigidbody.position + _position * _speed * Time.fixedDeltaTime);
    }


}
