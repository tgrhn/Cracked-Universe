using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isDash : MonoBehaviour
{
    // The speed of the dash
    public float dashSpeed = 10.0f;

    // The duration of the dash
    public float dashDuration = 4f;

    // The distance the object can dash
    public float dashDistance = 5.0f;

    // A timer for the dash duration
    private float dashTimer;
    private float cooldownTimer;

    // A flag to track if the object is currently dashing
    private bool isDashing;
    private bool isCoolDown;
    public Animator animator;

    // The rigidbody2D of the object
    private Rigidbody2D rb;

    // The original position of the object before the dash
    private Vector2 originalPosition;

    void Start()
    {
        // Get the rigidbody2D of the object
        
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // If the "E" key is pressed and the player is moving, start the dash
        if (Input.GetKeyDown(KeyCode.E) && horizontalInput != 0 && !isDashing && !isCoolDown)
        {
            StartDash(horizontalInput);
            animator.SetBool("dash", true);
        }

        // If the object is currently dashing, update the dash timer
        if (isDashing)
        {
            dashTimer += Time.deltaTime;
            // If the dash timer has exceeded the dash duration, stop the dash
            if (dashTimer > dashDuration)
            {
                StopDash();
            }
        }
        if (isCoolDown)
        {
            cooldownTimer += Time.deltaTime;
            // If the dash timer has exceeded the dash duration, stop the dash
            if (cooldownTimer > 2)
            {
                isCoolDown = false;
            }
        }
    }

    // A method to start the dash
    public void StartDash(float direction)
    {
        dashTimer = 0;

        // Set the isDashing flag to true
        isDashing = true;
    }

    // A method to stop the dash
    public void StopDash()
    {
        // Set the isDashing flag to false
        isDashing = false;
        dashTimer = 0;
        isCoolDown = true;
        cooldownTimer = 0;
        animator.SetBool("dash", false);

    }

    void FixedUpdate()
    {
        // If the object is currently dashing, move it forward at the dash speed
        if (isDashing)
        {
            rb.MovePosition(transform.position + transform.right * dashSpeed * Time.deltaTime);
        }
    }
}

