using UnityEngine;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;

    [SerializeField] private Button BackButton;

    void Start()
    {
        BackButton.onClick.AddListener(OnBackClicked);
    }

    private void OnBackClicked()
    {
        gameObject.SetActive(false);
        MainMenu.SetActive(true);
    }
}
