using UnityEngine;
using UnityEngine.SceneManagement;

public class GetWinChip : MonoBehaviour
{
    public float speed;
    [SerializeField] private int _levelToLoad;
    void OnCollisionEnter(Collision coll) {

        if(coll.collider.CompareTag("WinChip")) {

            gameObject.GetComponent<Animator>().SetTrigger("Jump");
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * speed, ForceMode.Impulse);
            Destroy(coll.gameObject);
        }
    }
    private void OnTriggerEnter(Collider coll) {
        if(coll.name == "Teleportation") {
            PlayerPrefs.SetInt("LoadLevel", _levelToLoad);
            SceneManager.LoadScene(_levelToLoad);
        }
    }
}