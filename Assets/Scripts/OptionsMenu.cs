using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;

    const string MASTER_KEY = "Master";
    const string SFX_KEY = "SFX";
    const string MUSIC_KEY = "Music";

    [SerializeField] private GameObject PauseMenu;

    [SerializeField] private Button BackButton;

    void Start()
    {
        BackButton.onClick.AddListener(OnBackClicked);

        // load saved slider values
        masterSlider.value = PlayerPrefs.GetFloat(MASTER_KEY, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat (SFX_KEY, 1f);
        musicSlider.value = PlayerPrefs.GetFloat (MUSIC_KEY, 1f);

        // apply audio levels based on saved values
       ApplyVolume(masterSlider.value, sfxSlider.value, musicSlider.value);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    void ApplyVolume(float master, float sfx, float music)
    {
        mixer.SetFloat("MasterVolume", LinearToDb(master));
        mixer.SetFloat("SFXVolume", LinearToDb(-master));
        mixer.SetFloat("MusicVolume", LinearToDb(-master));
    }

    float LinearToDb(float linear)
    {
        if (linear <= 0.0001f) return -80f;
        return Mathf.Log10(Mathf.Clamp(linear, 0.0001f, 1f)) * 20f;
    }

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat("MasterVolume", LinearToDb(value));
        PlayerPrefs.SetFloat(MASTER_KEY, value);
    }
    public void SetSfxVolume(float value)
    {
        mixer.SetFloat("SFXVolume", LinearToDb(value));
        PlayerPrefs.SetFloat(SFX_KEY, value);
    }
    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("MusicVolume", LinearToDb(value));
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
