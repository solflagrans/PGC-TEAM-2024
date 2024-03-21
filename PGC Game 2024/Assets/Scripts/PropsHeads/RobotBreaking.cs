using UnityEngine;

public class RobotBreaking : MonoBehaviour
{

    [SerializeField] private GameObject _smoke;
    [SerializeField] private GameObject _cube;
    [SerializeField] private Transform _cubePosition;
    private int _damaged;
    [SerializeField] private GameObject _bearCamera;
    [SerializeField] private GameObject _playerCamera;

    private void GiveDamage() {

        Invoke(nameof(OnSmoke), 2f);
        Invoke(nameof(OffSmoke), 5f);

        Instantiate(_cube, _cubePosition);

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

    }

    private void OnSmoke() {

        _smoke.SetActive(true);

    }
    private void OffSmoke() {

        _smoke.SetActive(false);

    }

}
