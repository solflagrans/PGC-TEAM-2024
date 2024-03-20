using UnityEngine;

public class FlyingPlatform : Platform
{

    [Header("Preferences [FlyingPlatform]")]
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject jumpText;

    private bool inTrigger;
    
    private MovingController _controller;

    public override void Start() {
        
        _controller = MovingController.Instance;

        base.Start();

    }

    public override void Update() {
        
        if(Vector3.Distance(_controller.transform.position, _target.transform.position) < 0.05f) {
            _controller.MovingMode = "Default";
            _controller.Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if(inTrigger) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                _controller.MovingMode = "Flying";
                _controller.Target = _target;
                _controller.Rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
                _controller.SpeedToTarget = _speed;
                jumpText.SetActive(false);
            }
        }

        base.Update();

    }

    private void OnTriggerEnter(Collider col) {

        if(col.gameObject.CompareTag("Player")) {
            jumpText.SetActive(true);
            inTrigger = true;
        }

    }

    private void OnTriggerExit(Collider col) {

        if(col.gameObject.CompareTag("Player")) {
            jumpText.SetActive(false);
            inTrigger = false;
        }

    }
}
