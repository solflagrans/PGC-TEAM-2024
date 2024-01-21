using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PreferencesLoad : MonoBehaviour
{
   [Header("VolumeSettings")]
   [SerializeField] private TextMeshProUGUI volumeTextValue = null;
   [SerializeField] private Slider volumeSlider = null;

   [Header("Graphic Settings")]
   [SerializeField]private Slider brightnessSlider = null;
   [SerializeField] private TextMeshProUGUI brightnessTextValue = null;

   [Header("Resolution DropDown")] 
   [SerializeField] private TMP_Dropdown resolutionDropDown;

   void Awake()
   {
      if (PlayerPrefs.HasKey("volume"))
      {
         float localVolume = PlayerPrefs.GetFloat("volume");
         volumeSlider.value = localVolume;
         AudioListener.volume = localVolume;
         volumeTextValue.text = localVolume.ToString("0.0");
      }
      if (PlayerPrefs.HasKey("brightness"))
      {
         float localBrightness = PlayerPrefs.GetFloat("volume");
         brightnessSlider.value = localBrightness;
         brightnessTextValue.text = localBrightness.ToString("0.0");
      }
      if (PlayerPrefs.HasKey("quality"))
      {
        int  localQuality = PlayerPrefs.GetInt("quality");
         QualitySettings.SetQualityLevel(localQuality );
      }
      if (PlayerPrefs.HasKey("fullScreen"))
      {
         float localFS= PlayerPrefs.GetInt("fullScreen");
         if (localFS == 1)
         {
            Screen.fullScreen = true;
         }
         else
         {
            Screen.fullScreen = false;
         }
      }
   }
   }
