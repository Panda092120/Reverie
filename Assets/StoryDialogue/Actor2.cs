using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//code for the npc
public class Actor2 : MonoBehaviour
{

    public string Name;
    public Dialogue2 Dialogue;

    public void SpeakTo()
    {
        DialogueManager2.instance.StartDialogue(Name, Dialogue.RootNode);
    }
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpeakTo();
        }
    }
    
}
