using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60f; 
    public TextMeshProUGUI timerText;
    private bool timerRunning = true;

    void Update()
    {
        if (timerRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            timerRunning = false;
            GameOver();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        Debug.Log("Game Over! Loading Game Over Scene");
        SceneManager.LoadScene("Game Over");
    }
}
