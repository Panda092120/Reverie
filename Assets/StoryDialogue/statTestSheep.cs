using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statTestSheep : MonoBehaviour
{
    void Start()
    {
        // Accessing the StatManager instance
        StatManager statManager = StatManager.Instance;

        // Example of modifying stats
        statManager.health += 10;
        //statManager.experience += 2;

        // Debugging to check values
        Debug.Log($"Health: {statManager.health}, Experience: {statManager.experience}");
    }
    

    private bool isPlayerInRange = false;
    // Detect when the player enters the NPC's interaction range
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    // Detect when the player leaves the NPC's interaction range
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void Update()
    {
        // Check if the player is in range and presses the interaction key, if so, add experience and check
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            StatManager statManager = StatManager.Instance;
            // Example of modifying stats
            statManager.health += 1;
            statManager.experience += 5;

            //levelup
            if(statManager.experience == 10)
            {
                statManager.experience = 0;
                statManager.health += 10;
                statManager.luck += 2;
            }

            // Debugging to check values
            Debug.Log($"Health: {statManager.health}, Experience: {statManager.experience}");
        }
    }
}
