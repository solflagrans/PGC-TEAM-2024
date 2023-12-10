using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{

    public int ltl;

    private void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Player")) {
            GoLoad();
        }
        
    }

    public void GoLoad() {
        PlayerPrefs.SetInt("ltl", ltl);
        SceneManager.LoadScene(1);
    }

}

