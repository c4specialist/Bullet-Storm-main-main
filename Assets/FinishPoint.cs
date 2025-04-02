using UnityEngine;
using UnityEngine.SceneManagement; // For scene loading

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        // Check if the current scene is not the last scene in the build settings
        if (currentSceneIndex + 1 < totalScenes)
        {
            // Load the next scene in the build settings
            SceneManager.LoadScene(currentSceneIndex + 1);

            PlayerPrefs.SetInt("UnlockedLevel", currentSceneIndex + 2); // Unlock the next level
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("You have completed the game!");
            SceneManager.LoadScene("Complete");
        }
    }
}
