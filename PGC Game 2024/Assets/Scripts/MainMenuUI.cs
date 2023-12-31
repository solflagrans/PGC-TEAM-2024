using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
   public GameObject settingsWindow;
   public GameObject mainMenuUI;
    public TMP_Dropdown dropdown;
    public Toggle fs;
   [Header("VolumeSettings")]
   [SerializeField] private TextMeshProUGUI volumeTextValue = null;
   [SerializeField] private Slider volumeSlider = null;
   [SerializeField] private float defaultVolume = 0.5f;

   [Header("Graphic Settings")]
   [SerializeField]private Slider brightnessSlider = null;
   [SerializeField] private TextMeshProUGUI brightnessTextValue = null;
   [SerializeField] private float defaultBrightness = 1f;

   private int qualityLevel;
   private bool isFullScreen;
   private float brightnessLevel;

   [Header("Resolution DropDown")] 
   [SerializeField] private TMP_Dropdown resolutionDropDown;

   private Resolution[] resolutions;
   int startRes;
   private void Start()
   {
      resolutions = Screen.resolutions;
      resolutionDropDown.ClearOptions();

      List<string> options = new List<string>();
      int resolutionIndex = 0;
      for (int i = 0; i < resolutions.Length; i++)
      {
         string option = resolutions[i].width + "x" + resolutions[i].height;
         options.Add(option);

         if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.width)
         {
            resolutionIndex = i;
         }
      }
      resolutionDropDown.AddOptions(options);
      resolutionDropDown.value = resolutionIndex;
      resolutionDropDown.RefreshShownValue();
   }

  public void SetResolution(int index)
   {
      Resolution resolution = resolutions[index];
      Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
   }

   public void QuitGame()
   {
      Application.Quit();
   }
   public void OpenSettingsWindow()
   {
      settingsWindow.SetActive(true);
      mainMenuUI.SetActive(false);
   }
   public void CloseSettingsWindow()
   {
      settingsWindow.SetActive(false);
      mainMenuUI.SetActive(true);
   }

   public void ResetSettings()
   {
      volumeSlider.value = defaultVolume;
      AudioListener.volume = defaultVolume;
      volumeTextValue.text = defaultVolume.ToString("0.0"); 
      brightnessLevel = defaultBrightness;
      brightnessTextValue.text = defaultBrightness.ToString("0.0");
      Apply();
   }
   public void SetBrightness(float brightness)
   {
      brightnessLevel = brightness;
      brightnessTextValue.text = brightness.ToString("0.0");
   }
   public void SetQuality(int quality)
   {
        qualityLevel = dropdown.value;
   }
   public void SetFullScreen(bool isFS)
   {
      isFullScreen = fs.isOn;
   }
   public void SetVolume(float volume)
   {
      volume = volumeSlider.value;
      AudioListener.volume = volume;
      volumeTextValue.text = volume.ToString("0.0");
   }

   public void Apply()
   {
      PlayerPrefs.SetFloat("volume",AudioListener.volume);
      PlayerPrefs.SetFloat("brightness", brightnessLevel);
      PlayerPrefs.SetInt("quality", qualityLevel);
      PlayerPrefs.SetInt("fullScreen", (isFullScreen ? 1 : 0));
      Screen.fullScreen = isFullScreen;
      QualitySettings.SetQualityLevel(qualityLevel);

        print(qualityLevel);
   }
}
