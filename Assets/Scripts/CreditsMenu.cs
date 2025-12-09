using UnityEngine;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;

    [SerializeField] private Button BackButton;

    [SerializeField] private Button MaxButton;
    [SerializeField] private Button NancyButton;
    [SerializeField] private Button DorinButton;
    [SerializeField] private Button ErikButton;
    [SerializeField] private Button SherryButton;
    [SerializeField] private Button LeaButton;
    [SerializeField] private Button LeniButton;
    [SerializeField] private Button MiaButton;


    void Start()
    {
        BackButton.onClick.AddListener(OnBackClicked);
        MaxButton.onClick.AddListener(OnMaxClicked);
        NancyButton.onClick.AddListener(OnNancyClicked);
        DorinButton.onClick.AddListener(OnDorinClicked);
        ErikButton.onClick.AddListener(OnErikClicked);
        SherryButton.onClick.AddListener(OnSherryClicked);
        LeaButton.onClick.AddListener(OnLeaClicked);
        LeniButton.onClick.AddListener(OnLeniClicked);
        MiaButton.onClick.AddListener(OnMiaClicked);
    }

    private void OnBackClicked()
    {
        gameObject.SetActive(false);
        MainMenu.SetActive(true);
    }

    private void OnMaxClicked()
    {
        Application.OpenURL("https://holymakarony.itch.io");
    }

    private void OnNancyClicked()
    { 
        Application.OpenURL("https://sparklecloud474.itch.io");
    }

    private void OnDorinClicked()
    {
        Application.OpenURL("https://2feldeeds.itch.io");
    }

    private void OnErikClicked()
    {
        Application.OpenURL("https://certainlyoverdone.itch.io");
    }
    private void OnSherryClicked()
    {
        Application.OpenURL("https://whoknowssql.itch.io");
    }
    private void OnLeaClicked()
    {

    }
    private void OnLeniClicked()
    {

    }
    private void OnMiaClicked()
    {

    }
}
