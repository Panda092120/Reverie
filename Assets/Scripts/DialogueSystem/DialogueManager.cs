using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;   // Reference to the Text component
    public GameObject dialogueBox;  // The GameObject containing the dialogue box UI
    public PlayerController playerController;  // Reference to the PlayerController script
    public Color textColor = Color.white;  // Default text color
    public Font textFont;  // Default font

    public float typingSpeed = 0.05f;  // Speed for letter-by-letter typing

    private List<string> currentDialogues;  // Holds the current NPC's dialogues
    private int dialogueIndex = 0;  // To track the current dialogue
    private bool isDialogueActive = false;  // To track if the dialogue system is currently running

    private void Start()
    {
        // Ensure the dialogue box is hidden at the start
        dialogueBox.SetActive(false);

        // Set the font and color
        dialogueText.color = textColor;
        dialogueText.font = textFont;
    }

    // Accept the specific NPC's dialogue list when starting dialogue
    public void StartDialogue(List<string> dialogues)
    {
        // If dialogue is already running, we don't want to restart it
        if (isDialogueActive) return;

        // Check if the dialogues list has content
        if (dialogues == null || dialogues.Count == 0)
        {
            Debug.LogError("No dialogues are available in the dialogues list.");
            return;  // Exit if no dialogues are present
        }

        currentDialogues = dialogues;  // Set the current dialogues to the NPC's dialogues
        isDialogueActive = true;  // Mark that the dialogue has started
        dialogueBox.SetActive(true);  // Show the dialogue box
        dialogueIndex = 0;  // Reset the dialogue index
        
        if (playerController != null)
        {
            playerController.SetCanMove(false);  // Disable player movement when dialogue starts
        }

        StartCoroutine(ShowText(currentDialogues[dialogueIndex]));  // Start the first dialogue
    }

    // Coroutine to display text letter by letter
    private IEnumerator ShowText(string dialogue)
    {
        dialogueText.text = "";  // Clear the text box before writing

        // Write each letter one by one
        foreach (char letter in dialogue)
        {
            dialogueText.text += letter;  // Add each letter one at a time
            yield return new WaitForSeconds(typingSpeed);  // Typing delay
        }

        // Wait until Z is pressed before moving to the next dialogue
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));

        dialogueIndex++;  // Move to the next dialogue element

        // If there's more dialogue, show it
        if (dialogueIndex < currentDialogues.Count)
        {
            StartCoroutine(ShowText(currentDialogues[dialogueIndex]));  // Display the next line
        }
        else
        {
            EndDialogue();  // End the dialogue when done
        }
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);  // Hide the dialogue box
        dialogueText.text = "";  // Clear the dialogue text
        isDialogueActive = false;  // Dialogue has finished

        if (playerController != null)
        {
            playerController.SetCanMove(true);  // Re-enable player movement after dialogue ends
        }
    }

    // Public method to check if dialogue is active
    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}
