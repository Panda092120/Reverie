using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float BASE_SPEED = 5;
    private Rigidbody2D rb;
    public KeyCode interact;

    private float currentSpeed;
    [SerializeField] private float JUMP_FORCE = 5f;
    [SerializeField] private float SPRINT_MULTIPLIER = 1.15f;
    private float sprintTime = 5f;
    private float sprintCooldown = 5f;
    private float sprintTimer = 0f;
    private float cooldownTimer = 0f;
    private bool isSprinting = false;
    private bool isCooldown = false;

    private Animator animator;
    private bool canMove = true;  // Flag to enable/disable movement

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentSpeed = BASE_SPEED;
    }

    void Update()
    {
        // If movement is disabled, don't allow any movement and return
        if (!canMove)
        {
            rb.velocity = Vector2.zero;  // Stop movement if disabled
            animator.Play("IdleAnimation");  // Force idle animation
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, vertical, 0);

        // Handle sprinting mechanics
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

        if (isCooldown)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= sprintCooldown)
            {
                isCooldown = false;
            }
        }

        // Move the player
        rb.velocity = new Vector2(dir.x * currentSpeed, dir.y * currentSpeed);

        // Update animation based on direction
        if (horizontal > 0)
        {
            animator.Play("rightWalkAnimation");
        }
        else if (horizontal < 0)
        {
            animator.Play("leftWalkAnimation");
        }
        else if (vertical > 0)
        {
            animator.Play("backWalkAnimation");
        }
        else if (vertical < 0)
        {
            animator.Play("frontWalkAnimation");
        }
        else
        {
            animator.Play("IdleAnimation");  // Play idle animation when not moving
        }
    }

    // Method to enable or disable player movement
    public void SetCanMove(bool canMoveStatus)
    {
        canMove = canMoveStatus;
        if (!canMove)
        {
            rb.velocity = Vector2.zero;  // Stop movement immediately
        }
    }
}
