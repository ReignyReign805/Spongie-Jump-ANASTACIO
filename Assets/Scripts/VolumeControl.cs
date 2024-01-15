using UnityEngine;

public class VolumeControl : MonoBehaviour
{
    void Start()
    {
        // Set the initial volume (you can set this to a saved preference)
        SetVolume(PlayerPrefs.GetFloat("Volume", 1.0f));
    }

    // Function to set the volume
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;

        // Save the volume preference
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}
