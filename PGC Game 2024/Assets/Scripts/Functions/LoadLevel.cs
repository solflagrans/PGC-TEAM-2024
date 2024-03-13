using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    [SerializeField] private int _levelToLoad;

    private void OnTriggerEnter(Collider col) {

        if(col.CompareTag("Player")) {
            GoLevel();
        }
        
    }

    private void GoLevel() {

        PlayerPrefs.SetInt("LoadLevel", _levelToLoad);
        SceneManager.LoadScene(_levelToLoad);

    }

    public void GoLevel(int level) {

        PlayerPrefs.SetInt("LoadLevel", level);
        SceneManager.LoadScene("Level Loading");

    }

}

