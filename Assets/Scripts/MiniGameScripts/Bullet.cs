using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class Projectile : MonoBehaviour
{

    MinigameController minigameController;
    // Start is called before the first frame update
    void Start()
    {
        minigameController = FindObjectOfType<MinigameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag == "Wall")
        {
            
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag == "Player")
        {
            minigameController.count++;
            Debug.Log("hit");
            Destroy(gameObject);
        }
        
    }
    
}
