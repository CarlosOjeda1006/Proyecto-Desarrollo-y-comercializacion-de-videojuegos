using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelController : MonoBehaviour
{
    public Slider volumeSlider;
    public GameObject pauseMenuUI;

    private AudioSource[] allAudioSources;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        volumeSlider.value = savedVolume;
        ApplyVolume(savedVolume);

        volumeSlider.onValueChanged.AddListener(ApplyVolume);
    }

    void ApplyVolume(float value)
    {
        PlayerPrefs.SetFloat("MasterVolume", value);
        PlayerPrefs.Save();

        allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (var audio in allAudioSources)
        {
            audio.volume = value;
        }
    }

    public void CloseSettingsPanel()
    {
        gameObject.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}

