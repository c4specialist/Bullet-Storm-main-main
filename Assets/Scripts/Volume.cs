using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Volume : MonoBehaviour
{
    public Slider volumeSlider;
    public TMP_Text volumeText;
    private const string VolumeKey = "GameVolume"; // Key to save volume

    void Start()
    {
        // Set min/max values first
        volumeSlider.minValue = 0;
        volumeSlider.maxValue = 100;
        volumeSlider.wholeNumbers = true;

        // Load saved volume or default to 50%
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 50);
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume / 100f;

        // Update UI
        UpdateVolumeText(savedVolume);

        // Add listener for changes
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    // Called when the slider value changes
    public void UpdateVolume(float value)
    {
        AudioListener.volume = value / 100f;
        UpdateVolumeText(value);

        // Save volume setting
        PlayerPrefs.SetFloat(VolumeKey, value);
        PlayerPrefs.Save();
    }

    // Updates the UI text
    public void UpdateVolumeText(float value)
    {
        volumeText.text = Mathf.RoundToInt(value) + "%";
    }
}
