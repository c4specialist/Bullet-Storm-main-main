using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void RestartGame()
    {
        string lastLevel = PlayerPrefs.GetString("LastLevel", "Level 1");
        SceneManager.LoadScene(lastLevel);
        Debug.Log("Restarted to : " + lastLevel);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu"); 
    }
}
