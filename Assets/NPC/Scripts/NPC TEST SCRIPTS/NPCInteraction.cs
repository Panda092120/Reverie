using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private List<string> npcDialogues;  // Serialized dialogue list for each NPC
    public DialogueManager dialogueManager;  // Reference to the shared DialogueManager

    private bool isPlayerInRange = false;

    private void Update()
    {
        // Check if the player is in range and presses the interaction key
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            StartNPCDialogue();
        }
    }

    private void StartNPCDialogue()
    {
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue(npcDialogues);  // Start the dialogue with this NPC's unique dialogues
        }
    }

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
}
