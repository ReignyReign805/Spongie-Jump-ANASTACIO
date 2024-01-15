using System.Collections;
using UnityEngine;

public class PadBehaviour : MonoBehaviour
{
    public float jumpForce = 5f;
    public AudioClip landingSound; // Added landing sound
    public AudioClip superRechargeSound; // Added super recharge sound

    private bool isEnabled = true; // Added flag to track the enabled state

    void OnCollisionEnter2D(Collision2D other)
    {
        if (isEnabled && other.relativeVelocity.y <= 0)
        {
            Rigidbody2D rb = other.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(0, jumpForce);

                // Check if the collided object is on a specific layer
                if (IsOnLayer(other.gameObject, "SuperRechargeLayer") && superRechargeSound != null)
                {
                    AudioSource.PlayClipAtPoint(superRechargeSound, transform.position);
                }
                else if (landingSound != null)
                {
                    AudioSource.PlayClipAtPoint(landingSound, transform.position);
                }
            }
        }
    }

    bool IsOnLayer(GameObject obj, string layerName)
    {
        // Check if the game object is on the specified layer
        return obj.layer == LayerMask.NameToLayer(layerName);
    }

    public void DisableOnHit()
    {
        isEnabled = false;
    }

    public void EnableOnRecovery(float delay)
    {
        StartCoroutine(EnableAfterDelay(delay));
    }

    IEnumerator EnableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isEnabled = true;
    }
}
