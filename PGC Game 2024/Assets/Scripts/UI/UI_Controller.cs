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
    public PlayerInformation statistics;

    [Header("Technical Variables")]
    private bool menuOpened;

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Escape)) ChangeMenuState();

        healthBar.value = statistics.Hp;
        honeyFiller.maxValue = statistics.MaxHoneyAmount;
        honeyFiller.value = Mathf.Floor((((float)statistics.CollectedHoney) / ((float)statistics.MaxHoneyAmount)) * 100);
        honeyPercentage.text = honeyFiller.value.ToString() + "%";
        honeyNumber.text = statistics.CollectedHoney.ToString() + " сот";

    }

    public void ChangeMenuState() {

        if(!menuOpened) {
            Time.timeScale = 0.3f;
            PauseUI.SetActive(true);
            menuOpened = true;
            Cursor.visible = true;
        } else {
            Time.timeScale = 1f;
            PauseUI.SetActive(false);
            menuOpened = false;
            Cursor.visible = false;
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
