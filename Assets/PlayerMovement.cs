using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement != Vector2.zero)
        {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);

        }

    }

    // updated consistently with the frame rate
    void FixedUpdate()
    {
        // movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }
}
