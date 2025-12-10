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
    const string MUSIC_KEY = "musicVolume";

    [SerializeField] private GameObject PauseMenu;

    [SerializeField] private Button BackButton;

    void Start()
    {
        BackButton.onClick.AddListener(OnBackClicked);

        masterSlider.value = PlayerPrefs.GetFloat(MASTER_KEY, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat (SFX_KEY, 1f);
        musicSlider.value = PlayerPrefs.GetFloat (MUSIC_KEY, 1f);

        SetMasterVolume(masterSlider.value);
        SetSfxVolume(sfxSlider.value);
        SetMusicVolume(musicSlider.value);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    float LinearToDb(float linear)
    {
        if (linear <= 0.0001f) return -80f;
        return Mathf.Log10(Mathf.Clamp(linear, 0.0001f, 1f)) * 20f;
    }

    public void SetMasterVolume(float value)
    {
        float db = LinearToDb(value);
        mixer.SetFloat("MasterVolume", db);
        PlayerPrefs.SetFloat(MASTER_KEY, value);
    }
    public void SetSfxVolume(float value)
    {
        float db = LinearToDb(value);
        mixer.SetFloat("SFXVolume", db);
        PlayerPrefs.SetFloat(SFX_KEY, value);
    }
    public void SetMusicVolume(float value)
    {
        float db = LinearToDb(value);
        mixer.SetFloat("MusicVolume", db);
        PlayerPrefs.SetFloat(MUSIC_KEY, value);
    }

    private void OnDisable()
    {
        PlayerPrefs.Save();
    }

    private void OnBackClicked()
    {
        gameObject.SetActive(false);
        PauseMenu.SetActive(true);
    }
    
}
