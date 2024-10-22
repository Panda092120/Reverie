using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Don't forget me!

public class BattleInteraction : MonoBehaviour
{
    [SerializeField] private List<string> npcDialogues;  // Serialized dialogue list for each NPC
    public DialogueManager dialogueManager;  // Reference to the shared DialogueManager

    private bool isPlayerInRange = false;

    [Header("Scene Swap")]
    [SerializeField] private bool battle;  // Determines whether or not this NPC will trigger a battle
    [SerializeField] private string sceneName;  // The scene we would like to move into after dialogue ends

    private bool triggerSceneSwap = false;  // Flag to check if we need to change scenes after dialogue

    private void Update()
    {
        // Check if the player is in range and presses the interaction key
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            // Start the NPC dialogue
            StartNPCDialogue();
        }

        // If the dialogue is finished and a scene swap is required, change scenes
        if (triggerSceneSwap && !dialogueManager.IsDialogueActive())
        {
            SaveSceneData();
            SceneManager.LoadScene(sceneName);
        }
    }

    private void StartNPCDialogue()
    {
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue(npcDialogues);  // Start the dialogue with this NPC's unique dialogues

            // If this NPC triggers a battle, set the flag to swap the scene after dialogue finishes
            if (battle)
            {
                triggerSceneSwap = true;
            }
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

    public void SaveSceneData()
    {
        SceneStateManager sceneStateManager = FindObjectOfType<SceneStateManager>();

        if (sceneStateManager != null)
        {
            sceneStateManager.SaveSceneState();
        }
        else
        {
            Debug.Log("Scene state manager is null");
        }
    }
}
