using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum DifficultyLevel
{
    Easy = 0,
    Medium = 1,
    Hard = 2
}

public class EasyMediumHard : MonoBehaviour
{
    public Slider difficultySlider;
    public TMP_Text difficultyText;

    void Start()
    {
        if (DifficultyManager.Instance == null)
        {
            Debug.LogError("DifficultyManager is missing");
        }
        else
        {
            LoadDifficulty();
        }

        difficultySlider.minValue = 0;
        difficultySlider.maxValue = 2;
        difficultySlider.wholeNumbers = true;

        difficultySlider.onValueChanged.AddListener(delegate { UpdateDifficulty(); });
        UpdateDifficultyText();
    }

    // Update the Difficulty in the DifficultyManager and save it to PlayerPrefs
    public void UpdateDifficulty()
    {
        if (DifficultyManager.Instance != null)
        {
            DifficultyManager.Instance.SetDifficulty((DifficultyLevel)(int)difficultySlider.value);
            Debug.Log("Difficulty updated: " + DifficultyManager.Instance.currentDifficulty);
            Debug.Log("Enemy health updated: " + DifficultyManager.Instance.enemyHealth);

            // Save the selected difficulty to PlayerPrefs
            PlayerPrefs.SetInt("Difficulty", (int)difficultySlider.value);
            PlayerPrefs.Save();
        }
    }

    // Update the displayed difficulty text based on the slider value
    public void UpdateDifficultyText()
    {
        switch ((int)difficultySlider.value)
        {
            case 0:
                difficultyText.text = "Easy";
                break;
            case 1:
                difficultyText.text = "Medium";
                break;
            case 2:
                difficultyText.text = "Hard";
                break;
            default:
                difficultyText.text = "Unknown";
                break;
        }
    }

    // Load difficulty setting from PlayerPrefs and set the slider value
    private void LoadDifficulty()
    {
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            int savedDifficulty = PlayerPrefs.GetInt("Difficulty");
            difficultySlider.value = savedDifficulty;
            UpdateDifficulty();
        }
        else
        {
            difficultySlider.value = 1; // Default to Medium
            UpdateDifficulty();
        }

        UpdateDifficultyText();
    }
}
