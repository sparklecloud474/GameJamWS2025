using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    [SerializeField] private Button BackButton;

    void Start()
    {
        
    }

    private void OnBackClicked()
    {
        gameObject.SetActive(false);
        PauseMenu.SetActive(true);
    }
    
}
