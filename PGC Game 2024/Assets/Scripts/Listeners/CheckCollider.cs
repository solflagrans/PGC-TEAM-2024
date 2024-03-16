using UnityEngine;

public class CheckCollider : MonoBehaviour
{

    private bool _playerIn;
    private bool _robotIn;

    public bool RobotIn { get => _robotIn; set => _robotIn = value; }
    public bool PlayerIn { get => _playerIn; set => _playerIn = value; }

    public void OnTriggerEnter(Collider col) {
        
        if(col.CompareTag("Player")) {
            _playerIn = true;
        }
        if(col.CompareTag("Robot")) {
            _robotIn = true;
        }

    }

    public void OnTriggerExit(Collider col) {
     
        if(col.CompareTag("Player")) {
            _playerIn = false;
        }
        if(col.CompareTag("Robot")) {
            _robotIn = false;
        }

    }

}
