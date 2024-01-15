using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public string gameplaySceneName = "Main";

    public void StartGame()
    {
        // Save the player's best score before loading the gameplay scene
        PlayerDataController.Instance.SavePlayerBestScore();

        // Load the gameplay scene
        SceneManager.LoadScene(gameplaySceneName);
    }
}
