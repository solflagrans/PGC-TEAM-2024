using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoadingController : MonoBehaviour
{
  [Header("Screen")]
  [SerializeField] private GameObject loadScreen;
  [SerializeField] private GameObject mainUI;
  
  [Header("Sclider")]
  [SerializeField] private Slider loadBar;

  public void LoadLevel(string levelName)
  {
    if (mainUI != null)
    {
      mainUI.SetActive(false);
    }

    loadScreen.SetActive(true);

    StartCoroutine(LoadLevelAsync(levelName));
  }

  IEnumerator LoadLevelAsync( string levelName)
  {
    AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelName);
    while (!loadOperation.isDone)
    {
      float progress = Mathf.Clamp01(loadOperation.progress / 0.9f);
      loadBar.value = progress;
      yield return null;
    }
  }
}
