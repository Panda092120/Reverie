using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour
{
    private static SceneStateManager instance;

    private string previousSceneName;
    private string currentSceneName;

    private void Awake()
    {
        // Ensure that there's only one instance of this object (Singleton Pattern)
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Prevent this object from being destroyed when loading a new scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        // Update the previous scene to the last current scene and set the new current scene
        previousSceneName = currentSceneName;
        currentSceneName = scene.name;

        Debug.Log($"Current scene: {currentSceneName}, Previous scene: {previousSceneName}");
    }

    // Method to go back to the previous scene without resetting it
    public void LoadPreviousScene()
    {
        if (!string.IsNullOrEmpty(previousSceneName))
        {
            SceneManager.LoadScene(previousSceneName, LoadSceneMode.Single);
        }
        else
        {
            Debug.LogWarning("No previous scene to return to.");
        }
    }

    // Method to store any custom scene state (example: player position, score, etc.)
    public void SaveSceneState()
    {
        // Example: you can implement saving game objects, player positions, or other data here
    }

    public void LoadSceneState()
    {
        // Example: you can implement loading the saved data for the scene here
    }
}