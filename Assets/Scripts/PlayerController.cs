using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _speed;

    private bool canMove = true;
    private PlayerControls _playerControls;
    private Rigidbody _rb;
    private Vector3 _movement;

    private const string IS_WALKING_PARAM = "IsWalking";
    // private const string IS_BACKWARDS_PARAM = "IsBackwards";
    private const int SPRINT_MULTIPLIER = 3;


    private void Awake() 
    {
        _playerControls = new PlayerControls();
    }
    
    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        float z = 0;

        if(canMove)
        {
            x = _playerControls.Player.Move.ReadValue<Vector2>().x;
            z = _playerControls.Player.Move.ReadValue<Vector2>().y;
        }

        _movement = new Vector3(x, 0, z).normalized;

    if (_playerControls.Player.Sprint.IsPressed() == true)
    {
        Sprint();
    }
    else
    {
        _movement = new Vector3(x, 0, z).normalized;
    }

    _anim.SetBool(IS_WALKING_PARAM, _movement != Vector3.zero);
    _anim.SetBool(IS_BACKWARDS_PARAM, _movement.z > 0);

    if (x != 0 && x < 0 && _movement.z <= 0)
    {
        _playerSprite.flipX = true;
    }

    else if (x != 0 && x > 0 && _movement.z <= 0)
    {
        _playerSprite.flipX = false;
    }

    else if (x != 0 && x < 0 && _movement.z > 0)
    {
        _playerSprite.flipX = false;
    }

    else if (x != 0 && x > 0 && _movement.z > 0)
    {
        _playerSprite.flipX = true;
    }

    }

    private void Sprint()
    {
        _movement = _movement * SPRINT_MULTIPLIER;
    }

    public void SetCanMove(bool CanMove)
    {
        canMove = CanMove;
    }
}
