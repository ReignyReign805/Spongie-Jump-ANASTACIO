using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    // Attach this script to a button's onClick event in the Inspector

    public void GoBackToMainScene()
    {
        // Replace "MainScene" with the actual name of your main scene
        SceneManager.LoadScene("MainMenu"); 
    }
}
