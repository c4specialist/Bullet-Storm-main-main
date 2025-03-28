using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;
    public DifficultyLevel currentDifficulty = DifficultyLevel.Medium;
    public int enemyHealth;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("DifficultyManager is on.");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDifficulty(DifficultyLevel difficulty)
    {
        currentDifficulty = difficulty;

        switch (difficulty)
        {
            case DifficultyLevel.Easy:
                enemyHealth = 50;
                break;
            case DifficultyLevel.Medium:
                enemyHealth = 100;
                break;
            case DifficultyLevel.Hard:
                enemyHealth = 150;
                break;
        }

        Debug.Log("Difficulty set to: " + currentDifficulty);
        Debug.Log("Enemy health updated to: " + enemyHealth);
    }
}
