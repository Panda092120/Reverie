using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagerClass : MonoBehaviour
{
    static public Vector3 savedPlayerPosition;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = savedPlayerPosition;
        }
    }
}