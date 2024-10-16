using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakout_PaddleMovement : MonoBehaviour
{
    public float speed = 7;
    public float maxX = 7.5f;

    float movementHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //paddle movement with a clamp to keep it in the camera
        movementHorizontal = Input.GetAxis("Horizontal");
        if((movementHorizontal > 0 && transform.position.x < maxX) || (movementHorizontal < 0 && transform.position.x  > -maxX))
        {
            transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        }
    }
}
