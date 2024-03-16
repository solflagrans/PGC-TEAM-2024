using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    [SerializeField] private int _levelToLoad;
    [SerializeField] private int _neededLevel;
    [SerializeField] private bool _needKey;

    private bool inTrigger;

    private void Update() {

        if(!inTrigger) return;

        if(_needKey) if(Input.GetKeyDown(KeyCode.E) && GameInformation.Instance.LastUnlockedLevel >= _neededLevel) GoLevel();
        if(!_needKey) if(GameInformation.Instance.LastUnlockedLevel >= _neededLevel) GoLevel();

    }

    private void OnTriggerEnter(Collider col) {

        if(col.CompareTag("Player")) {
            inTrigger = true;
        }
        
    }

    private void OnTriggerExit(Collider col) {
        
        if(col.CompareTag("Player")) {
            inTrigger = false;
        }

    }

    private void GoLevel() {

        //PlayerPrefs.SetInt("LoadLevel", _levelToLoad);
        SceneManager.LoadScene(_levelToLoad);

    }

}

