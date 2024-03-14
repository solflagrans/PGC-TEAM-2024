using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    [SerializeField] private int _levelToLoad;

    private bool inTrigger;

    private void Update() {

        if(!inTrigger) return;

        if(Input.GetKeyDown(KeyCode.E) && GameInformation.Instance.LastUnlockedLevel >= _levelToLoad) GoLevel();

    }

    private void OnTriggerEnter(Collider col) {

        if(col.CompareTag("Player")) {
            inTrigger = true;
        }
        
    }

    private void GoLevel() {

        //PlayerPrefs.SetInt("LoadLevel", _levelToLoad);
        SceneManager.LoadScene(_levelToLoad);

    }

}

