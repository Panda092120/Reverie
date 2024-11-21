using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    MinigameController minigameController;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        minigameController = FindObjectOfType<MinigameController>();
        audioManager = FindObjectOfType<AudioManager>(); // Find the AudioManager in the scene
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
<<<<<<< Updated upstream
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
        
=======
        if (collision.gameObject.tag != "Bullet")
        {
            if (collision.gameObject.tag == "Wall")
            {
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Player")
            {
                // Increment the counter in the MinigameController
                minigameController.count++;

                // Play the gotHit sound
                if (audioManager != null && audioManager.gotHit != null)
                {
                    audioManager.PlaySFX(audioManager.gotHit);
                }

                // Destroy the projectile
                Destroy(gameObject);

                Debug.Log("hit");
            }
        }
>>>>>>> Stashed changes
    }
}

