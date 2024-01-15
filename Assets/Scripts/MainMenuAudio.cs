using UnityEngine;

public class MainMenuAudio : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Play the audio
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
