using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoadingController : MonoBehaviour
{
  [Header("Screen")]
  [SerializeField] private GameObject loadScreen;
  [SerializeField] private GameObject mainUI;
  
  [Header("Slider")]
  [SerializeField] private Slider loadBar;

    [Header("Preferences")]
    public int ltl;

    private void Start() {
        if(ltl == 256) ltl = PlayerPrefs.GetInt("ltl", 2);
        LoadLevel(ltl);
    }

    public void LoadLevel(int levelNum) {
        if(mainUI != null) {
            mainUI.SetActive(false);
        }

        if(loadScreen != null) {
            loadScreen.SetActive(true);
        }

        StartCoroutine(LoadLevelAsync(levelNum));
    }

    IEnumerator LoadLevelAsync(int levelNum)
  {
    AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelNum);
    while (!loadOperation.isDone)
    {
      float progress = Mathf.Clamp01(loadOperation.progress / 0.9f);
      loadBar.value = progress;
      yield return null;
    }
  }
}
