using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//code for the npc
public class Actor2 : MonoBehaviour
{

    public string Name;
    public Dialogue2 Dialogue;
    public Dialogue2 Dialogue2;
    public Dialogue2 Dialogue3;
    public Dialogue2 Dialogue4;
    public Dialogue2 Dialogue5;
    public Dialogue2 Dialogue6;

    public void SpeakTo() //add additional effects using conditional statements here
    {
        StatManager statManager = StatManager.Instance;
        if (!(statManager.Act1))
        {
            DialogueManager2.instance.StartDialogue(Name, Dialogue.RootNode);
        }
        else if (statManager.Act1 == true && statManager.Act2 == false)
        {
            DialogueManager2.instance.StartDialogue(Name, Dialogue2.RootNode);
        }
        else if (statManager.Act2 == true && statManager.Act3 == false)
        {
            DialogueManager2.instance.StartDialogue(Name, Dialogue3.RootNode);
        }
        else if (statManager.Act3 == true && statManager.finalAct == false)
        {
            DialogueManager2.instance.StartDialogue(Name, Dialogue4.RootNode);
        }
        else if (statManager.finalAct ==  true && statManager.gameEnd == false)
        {
            DialogueManager2.instance.StartDialogue(Name, Dialogue5.RootNode);
        }
        else if (statManager.gameEnd)
        {
            DialogueManager2.instance.StartDialogue(Name, Dialogue6.RootNode);
        }
        else
        {
            Debug.Log("error");
        }
        //DialogueManager2.instance.StartDialogue(Name, Dialogue.RootNode);
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

    //checker to ensure that a NPC's dialogue does not run twice
    private bool check = false;

    // Update is called once per frame
    private void Update()
    {
        //initiate dialogue after checking stats
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Z) && check == false)
        {

            //StatManager statManager = StatManager.Instance;
            SpeakTo();

        }

    }

}
