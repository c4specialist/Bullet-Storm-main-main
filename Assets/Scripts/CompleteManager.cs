using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteManager : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Main Menu loaded"); 
    }
}
