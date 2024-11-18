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
        LoadSceneState();
    }

    // Method to go back to the previous scene without resetting it
    public void LoadPreviousScene()
    {
        if (!string.IsNullOrEmpty(previousSceneName))
        {
            SaveSceneState();
            SceneManager.LoadScene(previousSceneName, LoadSceneMode.Single);
            GameObject player = GameObject.FindWithTag("Player");

            float x = PlayerPrefs.GetFloat(previousSceneName + "_PlayerPosX");
            float y = PlayerPrefs.GetFloat(previousSceneName + "_PlayerPosY");
            float z = PlayerPrefs.GetFloat(previousSceneName + "_PlayerPosZ");
            player.transform.position = new Vector3(x, y, z);

        }
        else
        {
            Debug.Log("No previous scene to return to.");
        }
    }

    // Method to store any custom scene state (example: player position, score, etc.)
    public void SaveSceneState()
    {
        //you can implement saving game objects, player positions, or other data here
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;
            PlayerPrefs.SetFloat(currentSceneName + "_PlayerPosX", playerPosition.x);
            PlayerPrefs.SetFloat(currentSceneName + "_PlayerPosY", playerPosition.y);
            PlayerPrefs.SetFloat(currentSceneName + "_PlayerPosZ", playerPosition.z);
        }

        PlayerPrefs.Save();
        Debug.Log("Scene state saved.");
        
    }

    public void LoadSceneState()
    {
        // you can implement loading the saved data for the scene here
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && PlayerPrefs.HasKey(currentSceneName + "_PlayerPosX"))
        {
            float x = PlayerPrefs.GetFloat(currentSceneName + "_PlayerPosX");
            float y = PlayerPrefs.GetFloat(currentSceneName + "_PlayerPosY");
            float z = PlayerPrefs.GetFloat(currentSceneName + "_PlayerPosZ");
            player.transform.position = new Vector3(x, y, z);
            Debug.Log("Scene state loaded.");
        }
    }
}