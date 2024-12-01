using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 movement;
    private bool canMove = true; // To toggle movement when colliding with walls

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Vector2.zero; // Stop movement if collision prevents it
        }

        // Debugging movement
        Debug.Log($"Movement Input: {movement}");

        // Update animator parameters
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement != Vector2.zero)
        {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
        }
    }

    // Called consistently with the frame rate
    void FixedUpdate()
    {
        // Move player only when not colliding
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    // Detect when player starts colliding with walls
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision detected with: {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = false; // Disable movement
            Debug.Log("Colliding with Wall. Movement stopped.");
        }
    }

    // Detect when player stops colliding with walls
    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log($"Stopped colliding with: {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = true; // Re-enable movement
            Debug.Log("No longer colliding with Wall. Movement allowed.");
        }
    }

    // Debugging Collider Overlap Test
    void CheckColliderOverlap()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, transform.localScale, 0f);
        if (hit != null)
        {
            Debug.Log($"Overlapping with: {hit.gameObject.name}");
        }
    }

    void OnDrawGizmos()
    {
        // Visualize the player's collider in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
