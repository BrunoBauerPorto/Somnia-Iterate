using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSource.volume = savedVolume;
        musicSlider.value = savedVolume;

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    private void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    // Sempre aplica o volume salvo, mesmo se mudar a música
    public static void ApplySavedVolume(AudioSource newSource)
    {
        if (newSource != null)
            newSource.volume = PlayerPrefs.GetFloat("MusicVolume", 1f);
    }
}

