using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float BASE_SPEED = 5;
    private Rigidbody2D rb;
    public KeyCode interact;

    float currentSpeed;
<<<<<<< Updated upstream
    //private bool isGrounded = false;
=======
    [SerializeField] private float JUMP_FORCE = 5f;
    [SerializeField] private float SPRINT_MULTIPLIER = 1.15f; // Sprint increases speed by 15%
    private float sprintTime = 5f; // Sprint duration
    private float sprintCooldown = 5f; // Cooldown duration
    private float sprintTimer = 0f; // Tracks sprint time
    private float cooldownTimer = 0f; // Tracks cooldown time
    private bool isSprinting = false; // Sprinting state
    private bool isCooldown = false; // Cooldown state

    // Animator reference for controlling animations
    private Animator animator;
>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component

        currentSpeed = BASE_SPEED;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, vertical, 0);

        // Handle sprinting mechanics (same as before)
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && !isCooldown)
        {
            if (!isSprinting)
            {
                isSprinting = true;
                sprintTimer = 0f;
            }

            if (isSprinting && sprintTimer < sprintTime)
            {
                currentSpeed = BASE_SPEED * SPRINT_MULTIPLIER;
                sprintTimer += Time.deltaTime;
            }
            else
            {
                isSprinting = false;
                isCooldown = true;
                cooldownTimer = 0f;
            }
        }
        else
        {
            currentSpeed = BASE_SPEED;
        }

        // Handle cooldown (same as before)
        if (isCooldown)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= sprintCooldown)
            {
                isCooldown = false;
            }
        }

        // Move the player
        rb.velocity = new Vector2((dir * currentSpeed).x, (dir * currentSpeed).y);

        // Update animation based on direction
        if (horizontal > 0)  // Moving right
        {
            animator.Play("rightWalkAnimation");
        }
        else if (horizontal < 0)  // Moving left
        {
            animator.Play("leftWalkAnimation");
        }
        else if (vertical > 0)  // Moving up
        {
            animator.Play("backWalkAnimation");
        }
        else if (vertical < 0)  // Moving down
        {
            animator.Play("frontWalkAnimation");
        }
        else
        {
            // Stop walking animation if no movement
            animator.Play("IdleAnimation"); // Make sure you have an idle animation to default to when not moving
        }

        dir.Normalize();

        // Interact key logic (as before)
        if (Input.GetKeyDown(interact))
        {
            Debug.Log("Interact");
        }
    }
}
