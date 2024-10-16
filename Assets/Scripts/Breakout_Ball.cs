using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakout_Ball : MonoBehaviour
{
    //public float minY = -5.5f;
    public float maxVelocity = 15f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //if the ball falls outside of the scene
        if(transform.position.y < minY)
        {
        }
        */

        //ensures that the speed of the ball doesn't go crazy
        if(rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
        }
    }
}
