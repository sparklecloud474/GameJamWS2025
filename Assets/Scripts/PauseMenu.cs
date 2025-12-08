using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;

    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject GameUI;

    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button OptionsButton;
    [SerializeField] private Button BackToMainButton;

    [SerializeField] PlayerInput playerInput;
    InputAction pauseAction;

    void Start()
    {
        ResumeButton.onClick.AddListener(OnResumeClicked);
        OptionsButton.onClick.AddListener(OnOptionsClicked);
        BackToMainButton.onClick.AddListener(OnBackToMainClicked);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    GamePaused();
        //}
    }

    private void OnEnable()
    {
        pauseAction = playerInput.actions["Pause"];
        pauseAction.performed += OnPausePressed;
    }

    private void OnDisable()
    {
        pauseAction.performed -= OnPausePressed;
    }

    private void OnPausePressed(InputAction.CallbackContext ctx)
    {
        TogglePause(!isPaused);
    }

    private void TogglePause(bool paused)
    {
        isPaused = paused;

        gameObject.SetActive(isPaused);
        GameUI.SetActive(!isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }
    private void OnResumeClicked()
    {
        TogglePause(true);
    }

    private void OnOptionsClicked()
    { 
        gameObject.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    private void OnBackToMainClicked()
    {

    }

}
