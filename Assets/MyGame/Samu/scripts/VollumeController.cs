using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private const string VolumeKey = "MasterVolume";

    private void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("Keine AudioSource zugewiesen!");
            return;
        }

        float volume = PlayerPrefs.GetFloat(VolumeKey, 1f);

        audioSource.volume = volume;

        if (volumeSlider != null)
        {
            volumeSlider.value = volume;
            volumeSlider.onValueChanged.AddListener(UpdateVolume);
        }
        else
        {
            Debug.LogError("Kein Slider zugewiesen!");
        }
    }

    public void UpdateVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();

        Debug.Log("Neue Lautstärke: " + volume);
    }
}