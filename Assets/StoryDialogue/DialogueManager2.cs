using System.Threading;
using TMPro;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=dcPIuTS_usM&t=168s&ab_channel=Dul
public class DialogueManager2 : MonoBehaviour
{
    public static DialogueManager2 instance { get; private set; }

    //references
    public GameObject DialogueParent; // Main container for dialogue UI
    public TextMeshProUGUI DialogTitleText, DialogBodyText; // Text components for title and body
    public GameObject responseButtonPrefab; // Prefab for generating response buttons
    public Transform responseButtonContainer; // Container to hold response buttons

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of DialogueManager2
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Initially hide the dialogue UI
        HideDialogue();
    }

    // Starts the dialogue with given title and dialogue node
    public void StartDialogue(string title, DialogueNode2 node)
    {
        // Display the dialogue UI
        ShowDialogue();

        // Set dialogue title and body text
        DialogTitleText.text = title;
        DialogBodyText.text = node.dialogueText;

        // Remove any existing response buttons
        foreach (Transform child in responseButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // Create and setup response buttons based on current dialogue node
        foreach (DialogueResponse2 response in node.responses)
        {
            GameObject buttonObj = Instantiate(responseButtonPrefab, responseButtonContainer);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = response.responseText;

            // Setup button to trigger SelectResponse when clicked
            buttonObj.GetComponent<Button>().onClick.AddListener(() => SelectResponse(response, title));
        }
    }

    // Handles response selection and triggers next dialogue node
    public void SelectResponse(DialogueResponse2 response, string title)
    {
        // Check if there's a follow-up node
        if (!response.nextNode.IsLastNode())
        {
            StartDialogue(title, response.nextNode); // Start next dialogue
        }
        else
        {
            // If no follow-up node, end the dialogue
            HideDialogue();
        }
    }

    // Hide the dialogue UI
    public void HideDialogue()
    {
        DialogueParent.SetActive(false);
    }

    // Show the dialogue UI
    private void ShowDialogue()
    {
        DialogueParent.SetActive(true);
    }

    // Check if dialogue is currently active
    public bool IsDialogueActive()
    {
        return DialogueParent.activeSelf;
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
