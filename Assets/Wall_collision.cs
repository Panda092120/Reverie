using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collided
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player)
        {
            // Get the Rigidbody2D of the player
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Calculate the collision direction
                Vector2 collisionNormal = (collision.transform.position - transform.position).normalized;

                // Adjust movement based on collision direction
                if (Mathf.Abs(collisionNormal.x) > Mathf.Abs(collisionNormal.y))
                {
                    // Horizontal collision: Stop horizontal movement
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
                else
                {
                    // Vertical collision: Stop vertical movement
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                }

                Debug.Log("Player movement adjusted due to wall collision.");
            }
            else
            {
                Debug.LogWarning("Rigidbody2D component not found on player.");
            }
        }
        else
        {
            Debug.LogWarning("PlayerController not found on collided object.");
        }
    }
}
