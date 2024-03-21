using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotBreaking : MonoBehaviour
{

    [SerializeField] private GameObject _smoke;
    [SerializeField] private GameObject _cube;
    [SerializeField] private Transform _cubePosition;
    private int _damaged;
    [SerializeField] private GameObject _bearCamera;
    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private GameObject _continue;

    private void GiveDamage() {

        Invoke(nameof(OnSmoke), 2f);
        Invoke(nameof(OffSmoke), 5f);

        Instantiate(_cube, _cubePosition);

        if(_continue != null) _continue.SetActive(true);

    }

    private void OnTriggerEnter(Collider col) {
        
        if(col.gameObject.CompareTag("Cube")) {
            GiveDamage();
            _damaged += 1;
            _playerCamera.SetActive(false);
            _bearCamera.SetActive(true);
            Invoke(nameof(ReturnCam), 5f);
        }

    }

    private void ReturnCam() {

        _playerCamera.SetActive(true);
        _bearCamera.SetActive(false);
        SceneManager.LoadScene(1);

    }

    private void OnSmoke() {

        _smoke.SetActive(true);

    }
    private void OffSmoke() {

        _smoke.SetActive(false);

    }

}
