using UnityEngine;

public class FlyingPlatform : Platform
{

    [Header("Preferences [FlyingPlatform]")]
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private bool isUsed;
    
    private MovingController _controller;

    public override void Start() {
        
        _controller = MovingController.Instance;

        base.Start();

    }

    private void OnTriggerEnter(Collider col) {

        if(col.gameObject.CompareTag("Player")) {
            if(!isUsed) {
                _controller.MovingMode = "Flying";
                _controller.Target = _target;
                _controller.Rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
                _controller.SpeedToTarget = _speed;
            }
        }

    }

    private void OnTriggerExit(Collider col) {

        if(col.gameObject.CompareTag("Player")) {
            _controller.MovingMode = "Default";
            _controller.Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            isUsed = true;
        }

    }
}
