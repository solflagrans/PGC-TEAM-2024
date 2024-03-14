using TMPro;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    [SerializeField] private string _scrollText;

    private bool _scrollCollected;

    private void Update() {
        
        if(_scrollCollected) {
            if(Input.GetKeyDown(KeyCode.Return)) {
                UI_Controller.Instance.Scroll.SetActive(false);
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Robot")) {
            CollectScroll();
        }
    }

    private void CollectScroll() {

        UI_Controller.Instance.Scroll.SetActive(true);
        UI_Controller.Instance.Scroll.GetComponentInChildren<TextMeshProUGUI>().text = _scrollText;
        _scrollCollected = true;

    }

}
