using System.Collections;
using UnityEngine;

public class EnemyJellyfishSpawner : MonoBehaviour
{
    public GameObject enemyJellyfishPrefab;
    public float spawnInterval = 10f;
    public float minYPosition = -5f;
    public float maxYPosition = 5f;
    public float spawnTriggerDistance = 100f; // Set the distance at which jellyfish spawning is triggered

    private bool isSpawning = false; // Added flag to track whether spawning is enabled

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyJellyfishCoroutine());
    }

    IEnumerator SpawnEnemyJellyfishCoroutine()
    {
        while (true)
        {
            // Check if the player has reached the spawnTriggerDistance before enabling spawning
            if (PlayerDistanceReached())
            {
                isSpawning = true;
            }

            if (isSpawning)
            {
                SpawnEnemyJellyfish();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemyJellyfish()
    {
        Vector2 spawnPosition = new Vector2(transform.position.x, Random.Range(minYPosition, maxYPosition));
        Instantiate(enemyJellyfishPrefab, spawnPosition, Quaternion.identity);
    }

    bool PlayerDistanceReached()
    {
        // Replace this condition with your actual distance-checking logic
        // For example, you can use the player's position or score
        // For simplicity, using the distance along the y-axis in this example
        return transform.position.y >= spawnTriggerDistance;
    }
}
