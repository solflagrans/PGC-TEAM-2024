using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    [Header("Slider")]
    [SerializeField] private Slider _loadBar;

    private void Start() {

        StartCoroutine(LoadLevelAsync(PlayerPrefs.GetInt("LoadLevel", 2)));

    }

    IEnumerator LoadLevelAsync(int levelNum) {

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelNum);

        while (!loadOperation.isDone) {
            float progress = Mathf.Clamp01(loadOperation.progress / 0.9f);
            _loadBar.value = progress;
            yield return null;
        }

    }
}
