using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _speed;

    private bool canMove = true;
    private InputSystem_Actions _playerControls;
    private Rigidbody _rb;
    private Vector3 _movement;

    // Inputs
    InputAction interactAction;

    private const string IS_WALKING_PARAM = "IsWalking";
    private const string IS_BACKWARDS_PARAM = "IsBackwards";
    private const int SPRINT_MULTIPLIER = 3;


    private void Awake() 
    {
        _playerControls = new InputSystem_Actions();
    }
    
    private void OnEnable()
    {
        _playerControls.Enable();

        // get input actions
        interactAction = _playerControls.Player.Interact;
        interactAction.performed += OnInteractPressed;
    }

    private void OnDisable()
    {
        _playerControls.Disable();
        interactAction.performed -= OnInteractPressed;
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

        // _anim.SetBool(IS_WALKING_PARAM, _movement != Vector3.zero);
        // _anim.SetBool(IS_BACKWARDS_PARAM, _movement.z > 0);
        /*
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
        */

        if(interactAction.IsPressed() == true)
        {
            print("Interacted");
        }

        
    }
    
    private void FixedUpdate() 
    {
        _rb.MovePosition(transform.position + _movement * _speed * Time.fixedDeltaTime);    
    }

    private void Sprint()
    {
        _movement = _movement * SPRINT_MULTIPLIER;
    }

    public void SetCanMove(bool CanMove)
    {
        canMove = CanMove;
    }

    // Input Functions

    private void OnInteractPressed(InputAction.CallbackContext ctx)
    {
        Interact();
    }

    private void Interact()
    {
        print("Interact triggered");
    }
}
