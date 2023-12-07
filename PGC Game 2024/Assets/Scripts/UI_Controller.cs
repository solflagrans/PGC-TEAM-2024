using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject PauseUI;
    public Slider healthBar;
    public Slider honeyFiller;
    public TextMeshProUGUI honeyPercentage;
    public TextMeshProUGUI honeyNumber;
    public MC_InGameInformation statistics;

    [Header("Technical Variables")]
    private bool menuOpened;

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Escape)) ChangeMenuState();

        healthBar.value = statistics.hp;
        honeyFiller.maxValue = statistics.maxHoneyAmount;
        honeyFiller.value = Mathf.Floor((((float)statistics.collectedHoney) / ((float)statistics.maxHoneyAmount)) * 100);
        honeyPercentage.text = honeyFiller.value.ToString() + "%";
        honeyNumber.text = statistics.collectedHoney.ToString();

    }

    public void ChangeMenuState() {

        if(!menuOpened) {
            Time.timeScale = 0.3f;
            PauseUI.SetActive(true);
            menuOpened = true;
        } else {
            Time.timeScale = 1f;
            PauseUI.SetActive(false);
            menuOpened = false;
        }

    }

   public void Restart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;

   }
   
   public void ToMenu () {

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

   }
}
