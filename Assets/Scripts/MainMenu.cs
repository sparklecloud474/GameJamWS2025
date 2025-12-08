using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button StartGameButton;
    [SerializeField] private Button CreditsButton;
    [SerializeField] private Button QuitGameButton;

    [SerializeField] private GameObject CreditsMenu;
    [SerializeField] private GameObject GameUI;

    void Start()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;

        StartGameButton.onClick.AddListener(OnStartClicked);
        CreditsButton.onClick.AddListener(OnCreditsClicked);
        QuitGameButton.onClick.AddListener(OnQuitClicked);
    }

    private void OnStartClicked()
    { 
        gameObject.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1f;
    }

    private void OnCreditsClicked()
    { 
        gameObject.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    private void OnQuitClicked()
    { 
        Application.Quit();
    }
}
