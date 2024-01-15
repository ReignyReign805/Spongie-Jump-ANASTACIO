using System.Collections;
using UnityEngine;

public class EnemyJellyfish : MonoBehaviour
{
    public float speed = 3f;

    void Start()
    {
        StartCoroutine(MoveHorizontalCoroutine());
    }

    IEnumerator MoveHorizontalCoroutine()
    {
        while (true)
        {
            MoveHorizontal();
            yield return null;
        }
    }

    void MoveHorizontal()
    {
        float horizontalMove = speed * Time.deltaTime;
        transform.Translate(Vector2.right * horizontalMove);

        // Check if the jellyfish is out of the screen on the right
        if (transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)
        {
            // If yes, change direction to the left
            speed = -Mathf.Abs(speed);
        }

        // Check if the jellyfish is out of the screen on the left
        if (transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x)
        {
            // If yes, change direction to the right
            speed = Mathf.Abs(speed);
        }
    }
}