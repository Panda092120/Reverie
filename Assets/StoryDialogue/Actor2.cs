using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//code for the npc
public class Actor2 : MonoBehaviour
{

    public string Name;
    public Dialogue2 Dialogue;

    public void SpeakTo() //add additional effects using conditional statements here
    {
        DialogueManager2.instance.StartDialogue(Name, Dialogue.RootNode);
    }
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */

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

    //checker to ensure that a NPC's dialogue does not run twice
    private bool check = false;

    // Update is called once per frame
    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpeakTo();
        }
        */
        //initiate dialogue after checking stats
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Z) && check == false)
        {

            StatManager statManager = StatManager.Instance;
            // testing, work; can access stats and change stats
            if (statManager.Act1)
            {
                Debug.Log($"Act1 is true");
            }
            if (statManager.Act2)
            {
                Debug.Log($"Act2 is true");
            }
            if (!(statManager.Act1 = true))
            {
                Debug.Log($"Act1 is false");
            }

            if (!(statManager.Act2 = true))
            {
                Debug.Log($"Act2 is false changing it to true");
                statManager.Act1 = true;
            }
            if ((statManager.Act2)) //should run over everything else
            {
                Debug.Log($"Act2 is true now");
                SpeakTo();
            }
            if (!(statManager.Act2))
            {
                Debug.Log($"Act2 is still false, fix the error");
            }

            check = true;

        }

    }
    
}
