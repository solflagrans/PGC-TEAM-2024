using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    public int ltl;
    public GameObject mc;
    void OnTriggerStay(Collider coll){
        if(Input.GetKey(KeyCode.E) && mc.GetComponent<MC_InGameInformation>().maxLevel >= ltl){
            if(coll.CompareTag("Player") )
            {
               GoLoad();
            }
        } 
    }

    public void GoLoad() {
        PlayerPrefs.SetInt("ltl", ltl);
        SceneManager.LoadScene(1);
    }

}

