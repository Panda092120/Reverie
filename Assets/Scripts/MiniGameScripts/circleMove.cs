using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class circleMove : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed = 5f;
    public bool moveRight;
    public Transform pointA, pointB;

    public GameObject target;
    public KeyCode space;
    private bool isOverlap = false;
    public int count = 0;
    public int healthCount = 3;
    void Start()
    {
        //target = GameObject.Find("line").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (transform.position.x <= pointB.position.x)
        {
            moveRight = true;
        }
        if(transform.position.x >= pointA.position.x)
        {
            moveRight = false;
        }

        if (isOverlap && Input.GetKeyDown(space))
        {
            Debug.Log("yay");
            count++;
            
        }

        if (!isOverlap && Input.GetKeyDown(space))
        {
            Debug.Log("nay");
            healthCount--;
            if (healthCount == 0)
            {
                Destroy(gameObject);
            }
        }
        
    }

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
