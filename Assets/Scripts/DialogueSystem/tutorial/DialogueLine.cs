using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem 
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;
        
        [Header("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont; 

        private void Awake() {
            textHolder = GetComponent<Text>();
            
            // Set initial font and color
            textHolder.color = textColor;
            textHolder.font = textFont;
            
            // Start the coroutine to display the text letter by letter
            StartCoroutine(WriteText(input, textHolder));
        }

        // Coroutine to display text letter by letter
        private IEnumerator WriteText(string textToWrite, Text textHolder)
        {
            textHolder.text = "";  // Clear any pre-existing text
            foreach (char letter in textToWrite)
            {
                textHolder.text += letter;  // Add each letter one by one
                yield return new WaitForSeconds(0.05f);  // Add delay between letters
            }
        }
    }
}
