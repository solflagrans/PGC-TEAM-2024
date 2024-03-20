using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuUI : MonoBehaviour
{

    private AudioSource _audioSource;

    [SerializeField] private Image _continue;

    [Header("Windows")]
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _mainMenu;

    [Header("Volume")]
    [SerializeField] private TextMeshProUGUI _volumeText;
    [SerializeField] private Slider _volumeSlider;

    [Header("Graphic")]
    [SerializeField] private TMP_Dropdown _quality;
    [SerializeField] private Toggle _fullscreen;

    [Header("Resolution")] 
    [SerializeField] private TMP_Dropdown _resolutionDropDown;
    private Resolution[] _resolutions;
    private int _resolutionIndex;

    private void Start() {

        _audioSource = gameObject.GetComponent<AudioSource>();

        _resolutions = Screen.resolutions;
        _resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < _resolutions.Length; i++) {
            string option = _resolutions[i].width + "x" + _resolutions[i].height;
            options.Add(option);

            if (_resolutions[i].width == Screen.width && _resolutions[i].height == Screen.width)
            {
                _resolutionIndex = i;
            }
        }
        _resolutionDropDown.AddOptions(options);
        _resolutionDropDown.value = _resolutionIndex;

        LoadSettings();

        _resolutionDropDown.RefreshShownValue();


        if(!PlayerPrefs.HasKey("LastLevel")) {
            _continue.color = new Color(_continue.color.r / 2, _continue.color.g / 2, _continue.color.b / 2);
        }


    }

    public void MakeClick() {

        _audioSource.PlayOneShot(AudioHandler.Instance.menuPress);

    }

    public void NewGame() {

        PlayerPrefs.DeleteAll();
        SaveSettings();

        SceneManager.LoadScene(2);

    }

    public void ContinueGame() {

        if(!PlayerPrefs.HasKey("LastLevel")) return;

        SceneManager.LoadScene(1);

    }

    public void SwitchMenu() {

        _settings.SetActive(!_settings.activeSelf);
        _mainMenu.SetActive(!_mainMenu.activeSelf);

    }

    public void QuitGame() {

        Application.Quit();

    }

    public void ResetSettings() {

        _volumeSlider.value = 1f;
        SetVolume();

        _resolutionDropDown.value = _resolutionIndex;
        SetResolution();

        _fullscreen.isOn = false;
        SetFullScreen();

        _quality.value = 0;
        SetQuality();

    }

    public void SetResolution() {

        int index = _resolutionDropDown.value;
        Resolution resolution = _resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }

    public void SetQuality() {

        QualitySettings.SetQualityLevel(_quality.value);

    }

    public void SetFullScreen() {

        Screen.fullScreen = _fullscreen.isOn;

    }

    public void SetVolume() {

        float volume = _volumeSlider.value;
        AudioListener.volume = volume;
        _volumeText.text = Mathf.Floor(volume * 100) + "%";

    }

    public void SaveSettings() {

        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
        PlayerPrefs.SetInt("Quality", _quality.value);
        PlayerPrefs.SetInt("Fullscreen", _fullscreen.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Resolution", _resolutionDropDown.value);
        PlayerPrefs.Save();

    }

    public void LoadSettings() {

        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1);
        _volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1);
        _volumeText.text = Mathf.Floor(_volumeSlider.value * 100) + "%";

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality", 2));
        _quality.value = PlayerPrefs.GetInt("Quality", 2);

        Screen.fullScreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1 ? true : false;
        _fullscreen.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1 ? true : false;

        Resolution resolution = _resolutions[PlayerPrefs.GetInt("Resolution", 0)];
        Screen.SetResolution(resolution.width, resolution.height, true);
        if(PlayerPrefs.HasKey("Resolution")) _resolutionDropDown.value = PlayerPrefs.GetInt("Resolution");

    }
}
