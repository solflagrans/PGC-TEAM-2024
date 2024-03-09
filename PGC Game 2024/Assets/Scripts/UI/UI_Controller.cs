using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    
    private AudioSource _audioSource;

    [Header("UI Elements")]
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider honeyFiller;
    [SerializeField] private TextMeshProUGUI honeyPercentage;
    [SerializeField] private TextMeshProUGUI honeyNumber;

    [Header("Technical Variables")]
    private bool menuOpened;

    private void Start() {

        _audioSource = GetComponent<AudioSource>();

    }

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Escape)) ChangeMenuState();

        healthBar.value = PlayerInformation.Instance.Hp;
        honeyFiller.maxValue = PlayerInformation.Instance.MaxHoneyAmount;
        honeyFiller.value = Mathf.Floor((((float)PlayerInformation.Instance.CollectedHoney) / ((float)PlayerInformation.Instance.MaxHoneyAmount)) * 100);
        honeyPercentage.text = honeyFiller.value.ToString() + "%";
        honeyNumber.text = PlayerInformation.Instance.CollectedHoney.ToString() + " сот";

    }

    public void ChangeMenuState() {

        if(!menuOpened) {
            Time.timeScale = 0.3f;
            PauseUI.SetActive(true);
            menuOpened = true;
            Cursor.visible = true;
            AudioHandler.Instance.MuteForMenu();
            _audioSource.PlayOneShot(AudioHandler.Instance._menuPress);
        } else {
            Time.timeScale = 1f;
            PauseUI.SetActive(false);
            menuOpened = false;
            Cursor.visible = false;
            AudioHandler.Instance.Unmute();
            _audioSource.PlayOneShot(AudioHandler.Instance._menuPress);
        }

    }

   public void Restart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        _audioSource.PlayOneShot(AudioHandler.Instance._menuPress);

    }
   
   public void ToMenu () {

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        _audioSource.PlayOneShot(AudioHandler.Instance._menuPress);

    }
}
