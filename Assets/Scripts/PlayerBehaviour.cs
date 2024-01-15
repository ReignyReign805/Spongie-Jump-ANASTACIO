using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private float movement = 0f;
    public float movementSpeed = 10f;
    public float jumpForce = 10f;
    private bool isGrounded = true;
    private bool isWalking = false;
    private bool isIdle = false;
    private bool hasJumped = false;
    private bool hasLanded = false;
    private bool spacebarPressed = false; // Added flag to track spacebar press
    private bool isHit = false; // Added flag to track hit animation
    private bool canMove = true; // Added flag to control movement

    public PadBehaviour padBehaviour; // Reference to the PadBehaviour script
    public AudioClip landingSound; // Added landing sound

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hasJumped = false;
        hasLanded = true;
        spacebarPressed = false;
        isHit = false;

        // Ensure to set the reference to the PadBehaviour script in the Inspector
        if (padBehaviour == null)
        {
            Debug.LogError("PadBehaviour script not found on the same GameObject.");
        }
    }

    void Update()
    {
        if (!isHit && canMove)
        {
            // Handle horizontal movement only if not hit and canMove is true
            movement = Input.GetAxis("Horizontal") * movementSpeed;

            // Flip the character's sprite based on movement direction
            if (movement > 0f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f); // Face right
            }
            else if (movement < 0f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f); // Face left
            }
        }

        // Handle jumping
        if (Input.GetButtonUp("Jump") && isGrounded && !hasJumped && !spacebarPressed && !isHit)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isIdle = false;
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsIdle", isIdle);
            animator.SetTrigger("Jump");
            hasJumped = true;
            hasLanded = false;
            spacebarPressed = true; // Set the flag to true when spacebar is pressed
        }

        // Check if the player is holding the spacebar during the jump
        if (!isGrounded && Input.GetButton("Jump"))
        {
            animator.SetBool("IsIdle", false);
        }

        // Handle hitting (e.g., when touched by a jellyfish)
        if (isHit)
        {
            // Play hit animation
            animator.SetBool("IsHit", true);

            // Disable PadBehaviour script during hit animation
            padBehaviour.DisableOnHit();

            // Recover from hit animation after a certain duration
            StartCoroutine(RecoverFromHitAnimation());
        }
    }

    IEnumerator RecoverFromHitAnimation()
    {
        float hitRecoveryTime = 1.0f; // Adjust as needed for the duration of your hit animation
        float verticalKnockbackForce = 2.0f; // Vertical knockback force
        float horizontalKnockbackForce = 10.0f; // Horizontal knockback force
        float knockbackDuration = 0.2f; // Duration for the vertical knockback

        // Apply vertical knockback force
        rb.velocity = new Vector2(rb.velocity.x, verticalKnockbackForce);

        canMove = false; // Disable movement during hit recovery

        yield return new WaitForSeconds(knockbackDuration);

        // Apply horizontal knockback force based on the direction the player is facing
        int knockbackDirection = (transform.localScale.x > 0) ? -1 : 1;
        rb.velocity = new Vector2(knockbackDirection * horizontalKnockbackForce, rb.velocity.y);

        yield return new WaitForSeconds(hitRecoveryTime - knockbackDuration);

        // Reset the hit animation state
        animator.SetBool("IsHit", false);
        isHit = false; // Reset the hit flag
        canMove = true; // Enable movement after hit recovery

        // Enable PadBehaviour script after hit animation recovery with a delay
        padBehaviour.EnableOnRecovery(1.0f); // Adjust the delay as needed

        // If the player is on a special platform, prevent jumping during the hit recovery
        if (IsOnSpecialPlatform())
        {
            animator.SetBool("IsIdleOnSpecialPlatform", true);
            isGrounded = true; // Player is considered grounded during hit recovery on the special platform
        }
        else
        {
            // Otherwise, reset the grounded state based on actual collisions
            isGrounded = CheckGroundedState();
        }
    }

    void FixedUpdate()
    {
        // Update the rigidbody's velocity for horizontal movement
        rb.velocity = new Vector2(movement, rb.velocity.y);

        // Update the walking animation parameter
        isWalking = Mathf.Abs(movement) > 0.5f;
        animator.SetBool("IsWalking", isWalking);

        // Update the isIdle animation parameter
        isIdle = !isWalking && isGrounded;

        // Check if the player is grounded
        if (isGrounded)
        {
            hasJumped = false;

            // Check if the player has landed since the last jump
            if (!hasLanded && Mathf.Abs(rb.velocity.y) < 0.01f)
            {
                hasLanded = true;
                isIdle = true;

                // Check if the player has landed on a special platform
                if (IsOnSpecialPlatform())
                {
                    // Handle the transition differently for the special platform
                    animator.SetBool("IsIdleOnSpecialPlatform", true);
                }
                else
                {
                    // Trigger the idle animation when landing on a regular platform
                    animator.SetBool("IsIdle", isIdle);
                }
            }
        }
    }

    bool IsOnSpecialPlatform()
    {
        // Implement your logic to check if the player is on a special platform
        // For example, check if the player is colliding with an object tagged as "SpecialPlatform"
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("SpecialPlatform"))
            {
                return true;
            }
        }

        return false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jellyfish"))
        {
            // Perform actions when touched by a jellyfish (e.g., take damage)

            // Trigger hit animation
            isHit = true;
        }
        else if (collision.gameObject.CompareTag("SuperRechargePad"))
        {
            // Handle interactions with the super recharge pad
            // For example, trigger a special effect or collect a power-up
            // You can add your logic here

            // Trigger landing sound for the super recharge pad if available
            if (padBehaviour.superRechargeSound != null)
            {
                AudioSource.PlayClipAtPoint(padBehaviour.superRechargeSound, transform.position);

                // Skip playing the regular landing sound
                return;
            }
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            spacebarPressed = false; // Reset the flag when the player is grounded
            isHit = false; // Reset the hit flag when grounded
        }

        // If it's not the SuperRechargePad, play the regular landing sound
        if (landingSound != null)
        {
            AudioSource.PlayClipAtPoint(landingSound, transform.position);
        }
    }


    // Additional helper method to check if the player is grounded based on collisions
    bool CheckGroundedState()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Ground"))
            {
                return true;
            }
        }

        return false;
    }
}
