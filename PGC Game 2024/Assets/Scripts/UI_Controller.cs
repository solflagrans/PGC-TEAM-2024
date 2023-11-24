using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject PauseUI;

    [Header("Technical Variables")]
    private bool menuOpened;

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Escape)) ChangeMenuState();

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
