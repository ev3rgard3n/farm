using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Sprite _mrFront, _mrBack, _mrLeft, _mrRight;

    public float x, y;
    private Vector2 _position;
    private Rigidbody2D _playerRigidbody;
    private SpriteRenderer _playerSprite;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerSprite = GetComponent<SpriteRenderer>();

        ChangeSprite(_mrFront);


    }
    
    public void ButtonUp(){
        Debug.Log("U");
        y+=1;
    }

    public void ButtonDown(){
        Debug.Log("D");
        y-=1;
    }

    public void ButtonLeft(){
        Debug.Log("L");
        x -= 1;
    }
    
    public void ButtonRight(){
        Debug.Log("R");
        x += 1;
    }

    public void ButtonStop(){
        Debug.Log("Stop");
        x = 0;
        y = 0;
    }

    private void ChangeSprite(Sprite sprite)
    {
        _playerSprite.sprite = sprite;
    }

    private void Update()
    {
        /* _position.x = Input.GetAxis("Horizontal");
         _position.y = Input.GetAxis("Vertical");*/
        _position = new Vector2(x, y);

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
