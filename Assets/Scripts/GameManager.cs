using System.Collections;
using System.Collections.Generic; // Add this line
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class GameManager : MonoBehaviour
{
    public GameObject padPrefab;
    public GameObject superPadPrefab;
    public GameObject enemyJellyfishPrefab;
    public int numPadsToMake = 10;
    int indexToCheck = 5;
    int indexToTranslate = 0;
    private float levelWidth;
    public float minVerticalDistance, maxVerticalDistance;
    List<GameObject> pads = new List<GameObject>();
    Vector2 spawnPosition;
    bool superCharge = false;

    int padsGeneratedCount = 0;
    int padsBetweenJellyfish = 10;

    public Animator spongeBobAnimator;
    public GameObject canvasPausePanel; // Reference to the PausePanel in the Canvas
    bool isPaused = false;

    void Start()
    {
        spawnPosition = transform.position;
        levelWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - padPrefab.GetComponent<SpriteRenderer>().bounds.extents.x / 2f;
        MakePads();

        StartCoroutine(ContinuousJellyfishSpawnCoroutine());
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!isPaused)
        {
            if (indexToCheck < pads.Count)
            {
                if (transform.position.y >= pads[indexToCheck].transform.position.y)
                {
                    TranslatePad(indexToTranslate);
                }
            }
        }
    }

    void MakePads()
    {
        for (int i = 0; i < numPadsToMake; i++)
        {
            MakePad();
            padsGeneratedCount++;

            if (padsGeneratedCount >= padsBetweenJellyfish)
            {
                padsGeneratedCount = 0;
                SpawnJellyfishOnPad(pads[i]);
            }
        }
    }

    void MakePad()
    {
        spawnPosition = new Vector2(0f, spawnPosition.y);
        spawnPosition += new Vector2(Random.Range(-levelWidth, levelWidth), Random.Range(minVerticalDistance, maxVerticalDistance));
        GameObject padTemp = null;
        if (!superCharge)
        {
            if (Random.Range(0, 3) == 0)
            {
                superCharge = true;
                padTemp = Instantiate(superPadPrefab, spawnPosition, Quaternion.identity);
            }
            else padTemp = Instantiate(padPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            padTemp = Instantiate(padPrefab, spawnPosition, Quaternion.identity);
        }

        padTemp.transform.localScale = new Vector3(0f, 0f, 0f);

        pads.Add(padTemp);
        StartCoroutine(GrowPad(padTemp));
    }

    void TranslatePad(int padIndex)
    {
        pads[padIndex].transform.position = new Vector2(0f, pads[padIndex].transform.position.y);
        spawnPosition = new Vector2(0f, spawnPosition.y);
        spawnPosition += new Vector2(Random.Range(-levelWidth, levelWidth), Random.Range(minVerticalDistance, maxVerticalDistance));
        pads[padIndex].transform.position = spawnPosition;
        StartCoroutine(GrowPad(pads[padIndex]));
        if (indexToTranslate < pads.Count - 1) indexToTranslate++;
        else indexToTranslate = 0;
        indexToCheck = (indexToTranslate + 5) % (pads.Count - 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jellyfish"))
        {
            spongeBobAnimator.SetBool("IsHit", true);
            StartCoroutine(RecoverFromHitAnimation());
        }
    }

    IEnumerator RecoverFromHitAnimation()
    {
        yield return new WaitForSeconds(1.0f);

        spongeBobAnimator.SetBool("IsHit", false);
    }

    IEnumerator GrowPad(GameObject obj)
    {
        float targetScale = 0.24f;

        for (int i = 0; i <= 10; i++)
        {
            float k = Mathf.Lerp(0f, targetScale, (float)i / 10);
            obj.transform.localScale = new Vector3(k, k, k);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator ContinuousJellyfishSpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SpawnJellyfishOnPad(pads[Random.Range(0, pads.Count)]);
        }
    }

    void SpawnJellyfishOnPad(GameObject pad)
    {
        if (pad != null)
        {
            Vector2 spawnPosition = pad.transform.position;
            Instantiate(enemyJellyfishPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        canvasPausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ContinueGame()
    {
        Debug.Log("Game Resumed"); // Add this debug log to ensure the method is called
        canvasPausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void StartAgain()
    {
        Time.timeScale = 1f; // Ensure time scale is reset to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Add any additional game state reset logic here
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Ensure time scale is reset to normal
        SceneManager.LoadScene("MainMenuScene"); // Replace "MainMenuScene" with the actual name of your main menu scene
                                             // Add any additional game state reset logic here if needed
    }

    public void LoadMainMenu()
    {
        PlayerDataController.Instance.SaveAndLoadData(); // Save and load data
        SceneManager.LoadScene("MainMenuScene"); // Load the main menu scene
    }
}