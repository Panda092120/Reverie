using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class DialogueNode2// : MonoBehaviour
{
    //response dialogue
    public string dialogueText;
    //options
    public List<DialogueResponse2> responses;

    internal bool IsLastNode()
    {
        return responses.Count <= 0;
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
