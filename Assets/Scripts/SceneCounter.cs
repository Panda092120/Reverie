using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCounter : MonoBehaviour
{
    private static SceneCounter instance;

    // Dictionary to keep track of scene visits
    private Dictionary<string, int> sceneVisitCount = new Dictionary<string, int>();

    private void Awake()
    {
        // Ensure that there's only one instance of this object (Singleton Pattern)
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        // Subscribe to the scene change event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the scene change event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        // Increment the visit count for the scene
        if (sceneVisitCount.ContainsKey(sceneName))
        {
            sceneVisitCount[sceneName]++;
        }
        else
        {
            sceneVisitCount[sceneName] = 1;
        }

        // Debug log to show the visit count
        Debug.Log($"Entered scene '{sceneName}' {sceneVisitCount[sceneName]} time(s).");
    }

    // Method to get the visit count for a specific scene
    public int GetSceneVisitCount(string sceneName)
    {
        return sceneVisitCount.ContainsKey(sceneName) ? sceneVisitCount[sceneName] : 0;
    }
}