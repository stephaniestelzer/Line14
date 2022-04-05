using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
      LoadValues();
    }

    public void Slider(float volume)
    {
        SaveVolumeButton();
    }

    public void SaveVolumeButton()
    {
      float volumeValue = volumeSlider.value;
      PlayerPrefs.SetFloat("VolumeValue", volumeValue);
      LoadValues();
    }

    void LoadValues()
    {
      float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
      volumeSlider.value = volumeValue;
      AudioListener.volume = volumeValue;
    }
}
