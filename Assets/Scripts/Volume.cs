using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Volume : MonoBehaviour
{
    public Slider volumeSlider;
    public TMP_Text volumeText;

    void Start()
    {
        volumeSlider.onValueChanged.AddListener(UpdateVolumeText);
        UpdateVolumeText(volumeSlider.value);
        volumeSlider.minValue = 0;
        volumeSlider.maxValue = 100;
        volumeSlider.wholeNumbers = true;
    }

    // Update is called once per frame
    public void UpdateVolumeText(float value)
    {
        volumeText.text = Mathf.RoundToInt(value) + "%";
    }
}
