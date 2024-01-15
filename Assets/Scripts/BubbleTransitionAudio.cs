using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleTransitionAudio : MonoBehaviour
{
    public AudioClip clickSound; // Drag your sound effect here in the Unity Editor
    private AudioSource audioSource;

    void Start()
    {
        GameObject clickSoundObject = GameObject.Find("ClickSound");
        if (clickSoundObject != null)
        {
            audioSource = clickSoundObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                Debug.Log("Audio source found and assigned successfully.");
            }
            else
            {
                Debug.LogWarning("Audio source component not found on the GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("GameObject with the name 'ClickSound' not found.");
        }
    }


    // Helper method to play a sound, checking if the audio source is enabled
    private void PlaySound()
    {
        if (audioSource != null)
        {
            // Temporarily enable the audio source, play the sound, and then disable it again
            bool wasEnabled = audioSource.enabled;
            audioSource.enabled = true;
            audioSource.PlayOneShot(clickSound);
            audioSource.enabled = wasEnabled;
        }
        else
        {
            Debug.LogWarning("Audio source is null. Unable to play sound.");
        }
    }

    // Method to handle the leaderboard button click
    public void OnLeaderboardButtonClick()
    {
        PlaySound();

    }

    // Method to handle the new game button click
    public void OnNewGameButtonClick()
    {
        PlaySound();

    }
}
