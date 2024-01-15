using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPageManager : MonoBehaviour
{
    public GameObject leaderboardPage;
    public Text playerNameText;
    public Text bestScoreText;

    private static LeaderboardPageManager instance;

    void Start()
    {
        // Ensure this GameObject persists across scenes
        GameObject parentObject = new GameObject("LeaderboardPageManager_Parent");
        DontDestroyOnLoad(parentObject);

        // Use SetParent method with worldPositionStays set to false
        transform.SetParent(parentObject.transform, false);

        leaderboardPage.SetActive(false);
    }

    public static LeaderboardPageManager Instance
    {
        get
        {
            if (instance == null)
            {
                // Try to find an existing instance in the scene
                instance = FindObjectOfType<LeaderboardPageManager>();

                // If not found, create a new instance
                if (instance == null)
                {
                    GameObject obj = new GameObject("LeaderboardPageManager");
                    instance = obj.AddComponent<LeaderboardPageManager>();
                }
            }
            return instance;
        }
    }

    public void ShowLeaderboard()
    {
        leaderboardPage.SetActive(true);
        UpdateLeaderboardText();
    }

    public void HideLeaderboard()
    {
        leaderboardPage.SetActive(false);
    }

    private void UpdateLeaderboardText()
    {
        // Assuming you have a reference to the PlayerDataController
        PlayerDataController playerDataController = PlayerDataController.Instance;

        if (playerDataController != null)
        {
            // Load best score and player name from PlayerDataController
            int bestScore = Mathf.FloorToInt(playerDataController.LoadPlayerBestScore());
            string playerName = playerDataController.PlayerUsername;

            // Check if the best score is greater than 0 before updating the text
            if (bestScore > 0)
            {
                playerNameText.text = playerName;
                bestScoreText.text = "                    " + bestScore;
                playerNameText.gameObject.SetActive(true); // Show the player name text
                bestScoreText.gameObject.SetActive(true); // Show the best score text
            }
            else
            {
                playerNameText.gameObject.SetActive(false); // Hide the player name text
                bestScoreText.gameObject.SetActive(false); // Hide the best score text
            }
        }
        else
        {
            Debug.LogError("PlayerDataController not found!");
        }
    }
}
