using UnityEngine;
using UnityEngine.Events;

public class PlayerDataController : MonoBehaviour
{
    private static PlayerDataController _instance;

    public static PlayerDataController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerDataController>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("PlayerDataController");
                    _instance = container.AddComponent<PlayerDataController>();
                    DontDestroyOnLoad(container); // Keep the container alive between scenes
                }
            }

            return _instance;
        }
    }

    public string PlayerUsername
    {
        get { return PlayerPrefs.GetString("PlayerUsername", ""); }
        set
        {
            PlayerPrefs.SetString("PlayerUsername", value);
            PlayerPrefs.Save();
            OnUsernameChanged.Invoke();
        }
    }

    public UnityEvent OnUsernameChanged = new UnityEvent();

    // Properties and UnityEvent for the second player
    public string PlayerUsername2
    {
        get { return PlayerPrefs.GetString("PlayerUsername2", ""); }
        set
        {
            PlayerPrefs.SetString("PlayerUsername2", value);
            PlayerPrefs.Save();
            OnUsernameChanged2.Invoke();
        }
    }

    public UnityEvent OnUsernameChanged2 = new UnityEvent();

    // Properties and UnityEvent for the third player
    public string PlayerUsername3
    {
        get { return PlayerPrefs.GetString("PlayerUsername3", ""); }
        set
        {
            PlayerPrefs.SetString("PlayerUsername3", value);
            PlayerPrefs.Save();
            OnUsernameChanged3.Invoke();
        }
    }

    public UnityEvent OnUsernameChanged3 = new UnityEvent();

    // Properties and UnityEvent for the fourth player
    public string PlayerUsername4
    {
        get { return PlayerPrefs.GetString("PlayerUsername4", ""); }
        set
        {
            PlayerPrefs.SetString("PlayerUsername4", value);
            PlayerPrefs.Save();
            OnUsernameChanged4.Invoke();
        }
    }

    public UnityEvent OnUsernameChanged4 = new UnityEvent();

    // Properties and UnityEvent for the fifth player
    public string PlayerUsername5
    {
        get { return PlayerPrefs.GetString("PlayerUsername5", ""); }
        set
        {
            PlayerPrefs.SetString("PlayerUsername5", value);
            PlayerPrefs.Save();
            OnUsernameChanged5.Invoke();
        }
    }

    public UnityEvent OnUsernameChanged5 = new UnityEvent();

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Keep the object alive between scenes
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject); // Destroy duplicate instances
            }
        }
    }

    public void SaveAndLoadData()
    {
        SavePlayerUsername();
        LoadPlayerUsername();
        OnUsernameChanged.Invoke(); // Trigger the event when the username changes
        LoadPlayerBestScore(); // Load the best score

        // If the best score is not set for the current user, set it to zero
        if (PlayerPrefs.HasKey(PlayerUsername + "_PlayerBestScore"))
        {
            SavePlayerBestScore();
        }

        // Save and load data for the second player
        SavePlayerUsername2();
        LoadPlayerUsername2();
        OnUsernameChanged2.Invoke();
        LoadPlayerBestScore2();

        // Save and load data for the third player
        SavePlayerUsername3();
        LoadPlayerUsername3();
        OnUsernameChanged3.Invoke();
        LoadPlayerBestScore3();

        // Save and load data for the fourth player
        SavePlayerUsername4();
        LoadPlayerUsername4();
        OnUsernameChanged4.Invoke();
        LoadPlayerBestScore4();

        // Save and load data for the fifth player
        SavePlayerUsername5();
        LoadPlayerUsername5();
        OnUsernameChanged5.Invoke();
        LoadPlayerBestScore5();

        // Add other save and load logic here if needed
    }

    private void SavePlayerUsername()
    {
        PlayerPrefs.SetString("PlayerUsername", PlayerUsername);
        PlayerPrefs.Save();
    }

    private void LoadPlayerUsername()
    {
        PlayerUsername = PlayerPrefs.GetString("PlayerUsername", "");
    }

    public void SavePlayerScore(float score)
    {
        PlayerPrefs.SetFloat(PlayerUsername + "_PlayerScore", score);
        PlayerPrefs.Save();
    }

    public float LoadPlayerBestScore()
    {
        return PlayerPrefs.GetFloat(PlayerUsername + "_PlayerBestScore", 0f);
    }

    public void SavePlayerBestScore()
    {
        float currentBestScore = LoadPlayerBestScore();
        float newBestScore = Mathf.Max(currentBestScore, PlayerPrefs.GetFloat(PlayerUsername + "_PlayerScore", 0f));
        PlayerPrefs.SetFloat(PlayerUsername + "_PlayerBestScore", newBestScore);
        PlayerPrefs.Save();
    }

    // Methods for the second player
    private void SavePlayerUsername2()
    {
        PlayerPrefs.SetString("PlayerUsername2", PlayerUsername2);
        PlayerPrefs.Save();
    }

    private void LoadPlayerUsername2()
    {
        PlayerUsername2 = PlayerPrefs.GetString("PlayerUsername2", "");
    }

    public void SavePlayerScore2(float score)
    {
        PlayerPrefs.SetFloat(PlayerUsername2 + "_PlayerScore", score);
        PlayerPrefs.Save();
    }

    public float LoadPlayerBestScore2()
    {
        return PlayerPrefs.GetFloat(PlayerUsername2 + "_PlayerBestScore", 0f);
    }

    public void SavePlayerBestScore2()
    {
        float currentBestScore2 = LoadPlayerBestScore2();
        float newBestScore2 = Mathf.Max(currentBestScore2, PlayerPrefs.GetFloat(PlayerUsername2 + "_PlayerScore", 0f));
        PlayerPrefs.SetFloat(PlayerUsername2 + "_PlayerBestScore", newBestScore2);
        PlayerPrefs.Save();
    }

    // Methods for the third player
    private void SavePlayerUsername3()
    {
        PlayerPrefs.SetString("PlayerUsername3", PlayerUsername3);
        PlayerPrefs.Save();
    }

    private void LoadPlayerUsername3()
    {
        PlayerUsername3 = PlayerPrefs.GetString("PlayerUsername3", "");
    }

    public void SavePlayerScore3(float score)
    {
        PlayerPrefs.SetFloat(PlayerUsername3 + "_PlayerScore", score);
        PlayerPrefs.Save();
    }

    public float LoadPlayerBestScore3()
    {
        return PlayerPrefs.GetFloat(PlayerUsername3 + "_PlayerBestScore", 0f);
    }

    public void SavePlayerBestScore3()
    {
        float currentBestScore3 = LoadPlayerBestScore3();
        float newBestScore3 = Mathf.Max(currentBestScore3, PlayerPrefs.GetFloat(PlayerUsername3 + "_PlayerScore", 0f));
        PlayerPrefs.SetFloat(PlayerUsername3 + "_PlayerBestScore", newBestScore3);
        PlayerPrefs.Save();
    }

    // Methods for the fourth player
    private void SavePlayerUsername4()
    {
        PlayerPrefs.SetString("PlayerUsername4", PlayerUsername4);
        PlayerPrefs.Save();
    }

    private void LoadPlayerUsername4()
    {
        PlayerUsername4 = PlayerPrefs.GetString("PlayerUsername4", "");
    }

    public void SavePlayerScore4(float score)
    {
        PlayerPrefs.SetFloat(PlayerUsername4 + "_PlayerScore", score);
        PlayerPrefs.Save();
    }

    public float LoadPlayerBestScore4()
    {
        return PlayerPrefs.GetFloat(PlayerUsername4 + "_PlayerBestScore", 0f);
    }

    public void SavePlayerBestScore4()
    {
        float currentBestScore4 = LoadPlayerBestScore4();
        float newBestScore4 = Mathf.Max(currentBestScore4, PlayerPrefs.GetFloat(PlayerUsername4 + "_PlayerScore", 0f));
        PlayerPrefs.SetFloat(PlayerUsername4 + "_PlayerBestScore", newBestScore4);
        PlayerPrefs.Save();
    }

    // Methods for the fifth player
    private void SavePlayerUsername5()
    {
        PlayerPrefs.SetString("PlayerUsername5", PlayerUsername5);
        PlayerPrefs.Save();
    }

    private void LoadPlayerUsername5()
    {
        PlayerUsername5 = PlayerPrefs.GetString("PlayerUsername5", "");
    }

    public void SavePlayerScore5(float score)
    {
        PlayerPrefs.SetFloat(PlayerUsername5 + "_PlayerScore", score);
        PlayerPrefs.Save();
    }

    public float LoadPlayerBestScore5()
    {
        return PlayerPrefs.GetFloat(PlayerUsername5 + "_PlayerBestScore", 0f);
    }

    public void SavePlayerBestScore5()
    {
        float currentBestScore5 = LoadPlayerBestScore5();
        float newBestScore5 = Mathf.Max(currentBestScore5, PlayerPrefs.GetFloat(PlayerUsername5 + "_PlayerScore", 0f));
        PlayerPrefs.SetFloat(PlayerUsername5 + "_PlayerBestScore", newBestScore5);
        PlayerPrefs.Save();
    }

    public Transform LoadTargetPlayer1()
    {
        GameObject player1 = GameObject.Find(PlayerUsername);
        return player1 != null ? player1.transform : null;
    }

    public Transform LoadTargetPlayer2()
    {
        GameObject player2 = GameObject.Find(PlayerUsername2);
        return player2 != null ? player2.transform : null;
    }

    public Transform LoadTargetPlayer3()
    {
        GameObject player3 = GameObject.Find(PlayerUsername3);
        return player3 != null ? player3.transform : null;
    }

    public Transform LoadTargetPlayer4()
    {
        GameObject player4 = GameObject.Find(PlayerUsername4);
        return player4 != null ? player4.transform : null;
    }

    public Transform LoadTargetPlayer5()
    {
        GameObject player5 = GameObject.Find(PlayerUsername5);
        return player5 != null ? player5.transform : null;
    }
}
