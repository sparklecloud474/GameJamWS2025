using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;

    const string MASTER_KEY = "masterVolume";
    const string SFX_KEY = "sfxVolume";

    [SerializeField] private GameObject PauseMenu;

    [SerializeField] private Button BackButton;

    void Start()
    {
        BackButton.onClick.AddListener(OnBackClicked);
    }

    private void OnBackClicked()
    {
        gameObject.SetActive(false);
        PauseMenu.SetActive(true);
    }
    
}
