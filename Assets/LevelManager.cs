using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int currentLevel; // Set this per level (1 for Level 1, 2 for Level 2, etc.)

    // This function should be called when the player completes a level
    public void CompleteLevel()
    {
        int highestLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // Get the currently unlocked level (default is 1)

        // Unlock next level if not already unlocked
        if (currentLevel >= highestLevel)
        {
            int newUnlockedLevel = currentLevel + 1;
            PlayerPrefs.SetInt("UnlockedLevel", newUnlockedLevel); // Save the new highest unlocked level
            PlayerPrefs.Save();
            Debug.Log("Level " + newUnlockedLevel + " unlocked!");
        }

        // Load the main menu after completing a level
        SceneManager.LoadScene("Main Menu");
    }

    // This function can be used to dynamically load the correct level based on the unlocked level
    public void LoadLevel(int levelToLoad)
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (levelToLoad <= unlockedLevel)
        {
            // If the level is unlocked, load it
            SceneManager.LoadScene("Level" + levelToLoad); // Assumes the levels are named "Level1", "Level2", etc.
        }
        else
        {
            Debug.Log("Level " + levelToLoad + " is locked!");
        }
    }
}
