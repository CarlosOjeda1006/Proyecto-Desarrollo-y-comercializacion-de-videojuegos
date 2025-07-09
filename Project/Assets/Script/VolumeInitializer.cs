using UnityEngine;

public class VolumeInitializer : MonoBehaviour
{
    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

        foreach (var audio in allAudioSources)
        {
            audio.volume = savedVolume;
        }
    }
}

