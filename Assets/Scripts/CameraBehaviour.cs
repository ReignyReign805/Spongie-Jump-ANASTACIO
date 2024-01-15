using UnityEngine;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour
{
    public Text scoreText;
    public Text loseText;
    public GameObject losePanel;
    public Transform target;
    public float cameraSpeed = 5f;
    bool lostGame = false;
    float visibilityTimer = 0f;
    public float visibilityThreshold = 3f;

    private float score = 0f;

    private void Update()
    {
        if (!lostGame)
        {
            if (target.transform.position.y > transform.position.y)
            {
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(transform.position.x, target.transform.position.y, transform.position.z), cameraSpeed * Time.deltaTime);
                score += Time.deltaTime * 15f;
                UpdateScoreText();
                visibilityTimer = 0f;
            }
            else
            {
                visibilityTimer += Time.deltaTime;
                if (visibilityTimer > visibilityThreshold)
                {
                    lostGame = true;
                    loseGame();
                }
            }
        }
        else
        {
            PlayerDataController playerDataController = PlayerDataController.Instance;
            playerDataController.SavePlayerScore(score);
            playerDataController.SaveAndLoadData();

            // Assuming you have a reference to the LeaderboardPageManager
            LeaderboardPageManager leaderboardPageManager = FindObjectOfType<LeaderboardPageManager>();

            if (leaderboardPageManager != null)
            {
                leaderboardPageManager.ShowLeaderboard(); // Show leaderboard and update the text
            }
         
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            lostGame = true;
            loseGame();
        }
    }

    void loseGame()
    {
        losePanel.SetActive(true);
        int bestScore = PlayerPrefs.GetInt("bestScore", 0);
        if (Mathf.FloorToInt(score) > bestScore)
        {
            bestScore = Mathf.FloorToInt(score);
            PlayerPrefs.SetInt("bestScore", bestScore);
            PlayerPrefs.Save();
        }
        loseText.text = "Distance:\n" + Mathf.FloorToInt(score) + "\n\nBest Record: \n" + bestScore;
        Destroy(target.gameObject);
        Time.timeScale = 0f;
    }

    void UpdateScoreText()
    {
        scoreText.text = "Distance: " + Mathf.FloorToInt(score);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void startAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
