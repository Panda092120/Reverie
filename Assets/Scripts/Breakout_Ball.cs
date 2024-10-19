using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakout_Ball : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxVelocity = 15f;

    Rigidbody2D rb;

    //this tracks the score for the damage (10 max)
    int destroyedBricks = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //
        rb.velocity = Vector2.down * 10f;

    }

    // Update is called once per frame
    void Update()
    {
        
        //if the ball falls outside of the scene
        if(transform.position.y < minY)
        {
            GameOver();
        }
        

        //ensures that the speed of the ball doesn't go crazy
        if(rb.velocity.magnitude > maxVelocity)
        {
            //rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
            rb.velocity = Vector2.down * 10f;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            destroyedBricks++;
            //player destroyed all bricks
            if(destroyedBricks == 10)
            {
                Destroy(gameObject);
            }
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Destroy(gameObject);
    }

}
