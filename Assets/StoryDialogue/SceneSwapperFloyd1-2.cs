using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //dont forget me!

public class SceneSwapper : MonoBehaviour
{
#pragma warning disable 0649 //private variables
    [SerializeField] private string sceneName;
#pragma warning restore 0649

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        PlayerManager playerManager = FindObjectOfType<PlayerManager>();
        GameObject players = GameObject.FindWithTag("Player");
        
        if (playerManager != null)
        {
            PlayerManager.savedPlayerPosition = players.transform.position;
        }

        if (player) SceneManager.LoadScene(sceneName);
    }
}
