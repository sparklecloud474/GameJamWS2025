using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private GameObject pauseMenu;

    public bool canMove = true;

    private InputSystem_Actions _playerControls;
    private Rigidbody _rb;
    private Vector3 _movement;
    private GameObject interactable;
    private bool infrontOfInteractable;
    private Animator _anim;
    private SpriteRenderer _playerSprite;

    // Inputs
    InputAction interactAction;
    InputAction skillCheckAction;

    private const string IS_WALKING_PARAM = "IsWalking";
    private const string IS_BACKWARDS_PARAM = "IsBackwards";
    private const string IS_SIDEWAYS_PARAM = "IsSideways";
    private const int SPRINT_MULTIPLIER = 3;
    private const string INTERACTABLE = "Interactable";
    private const string IS_INFRONTOFINTERACTABLE_PARAM = "InfrontOfInteractable";

    //footstepsound
    public AudioClip[] footstepClip;
    public float stepInterval = 0.45f;

    private AudioSource audioSource;
    private float stepTimer = 0.0f;


    private void Awake() 
    {
        _playerControls = new InputSystem_Actions();
        _anim = gameObject.GetComponent<Animator>();
        _playerSprite = gameObject.GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();
    }
    
    private void OnEnable()
    {
        _playerControls.Enable();

        // get input actions
        interactAction = _playerControls.Player.Interact;
        skillCheckAction = _playerControls.Player.SpaceAction;
        interactAction.performed += OnInteractPressed;
        skillCheckAction.performed += OnSpaceActionPressed;
    }

    private void OnDisable()
    {
        _playerControls.Disable();
        interactAction.performed -= OnInteractPressed;
        skillCheckAction.performed -= OnSpaceActionPressed;
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

        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePauseMenu();
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
        _anim.SetBool(IS_SIDEWAYS_PARAM, _movement.x > 0 || _movement.x < 0);

        if (x < 0)
        {
            _playerSprite.flipX = false;
        }
        else if (x > 0)
        {
            _playerSprite.flipX = true;
        }
        /*
        if (x != 0 && x < 0 && _movement.z <= 0)
        {
            _playerSprite.flipX = false;
        }

        else if (x != 0 && x > 0 && _movement.z <= 0)
        {
            _playerSprite.flipX = true;
        }

        else if (x != 0 && x < 0 && _movement.z > 0)
        {
            _playerSprite.flipX = true;
        }

        else if (x != 0 && x > 0 && _movement.z > 0)
        {
            _playerSprite.flipX = false;
        }
        */

        HandleFootsteps();

    }
    
    private void FixedUpdate() 
    {
        _rb.MovePosition(transform.position + _movement * _speed * Time.fixedDeltaTime);    
    }

    private void OnTriggerEnter(Collider other) 
    {
        print("Collider entered");

        if (other.gameObject.tag == INTERACTABLE)
        {
            print("Interactable found");
            infrontOfInteractable = true;
            interactable = other.gameObject;
            interactable.GetComponent<Interactable>().ShowInteractPrompt(true);
            _anim.SetBool(IS_INFRONTOFINTERACTABLE_PARAM, true);
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == INTERACTABLE)
        {
            infrontOfInteractable = false;
            interactable.GetComponent<Interactable>().ShowInteractPrompt(false);
            interactable = null;
            _anim.SetBool(IS_INFRONTOFINTERACTABLE_PARAM, false);
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

    // Input Functions

    // interact
    private void OnInteractPressed(InputAction.CallbackContext ctx)
    {
        Interact();
    }

    private void Interact()
    {
        if (canMove == true)
        {
            print("Interact triggered");
            if(infrontOfInteractable == true && interactable != null)
            {
                interactable.GetComponent<Interactable>().Interact();
            }
        }
    }

    // skill check
    private void OnSpaceActionPressed(InputAction.CallbackContext ctx)
    {
        GameObject skillCheckPuzzle = GameObject.FindWithTag("SkillCheckGame");
        if (skillCheckPuzzle.GetComponent<SkillCheckPuzzle>().bActivateGame == true)
        {
            skillCheckPuzzle.GetComponent<SkillCheckPuzzle>().CheckValue();
        }
    }

    private void TogglePauseMenu()
    {
        bool isActive = pauseMenu.activeSelf;
        pauseMenu.SetActive(!isActive);

        if(isActive)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }

    private void HandleFootsteps()
    {
        bool isWalking = _movement.magnitude > 0.1f && canMove == true;

        if(!isWalking)
        {
            stepTimer = 0;
            return;
        }

        stepTimer -= Time.deltaTime;

        if(stepTimer <= 0f)
        {
            PlayFootsteps();
            stepTimer = stepInterval;
        }
    }

    private void PlayFootsteps()
    {
        if (footstepClip.Length == 0 || audioSource == null) return;

        AudioClip clip = footstepClip[Random.Range(0, footstepClip.Length)];
        audioSource.PlayOneShot(clip);
    }

}
