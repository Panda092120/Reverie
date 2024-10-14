using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class circleMove : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed = 10f;
    public bool moveRight;
    public Transform pointA, pointB;

    public GameObject target;
    public KeyCode space;
    private bool isOverlap = false;
    void Start()
    {
        //target = GameObject.Find("line").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //tells the position using the vector function
        if (moveRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        //tells the direction that the circle will go
        if (transform.position.x <= pointB.position.x)
        {
            moveRight = true;
        }
        if(transform.position.x >= pointA.position.x)
        {
            moveRight = false;
        }

        //if space is pressed when the circle in on top of the line, then yay, else nay
        if (isOverlap && Input.GetKeyDown(space))
        {
            Debug.Log("yay");
        }

        if (!isOverlap && Input.GetKeyDown(space))
        {
            Debug.Log("nay");
            Destroy(gameObject);
            return;
        }
        
    }

    //see if the gameObject line is overlapping with the circle
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == target)
        {
            isOverlap = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == target)
        {
            isOverlap = false;
           
        }
    }
    
    

    
}
