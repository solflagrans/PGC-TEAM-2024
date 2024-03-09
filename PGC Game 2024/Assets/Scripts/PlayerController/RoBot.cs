using Unity.VisualScripting;
using UnityEngine;

public class RoBot : MonoBehaviour
{

    [Header("Preferences")]
    [SerializeField] private float _movingSpeed;

    [Header("Instances")]
    [SerializeField] private Transform _idlePosition;
    private Animator _animator;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Camera _robotCamera;
    [SerializeField] private MovingController _controller;
    [SerializeField] private PlayerVisual _playerVisual;
    private CharacterController _movement;
    [SerializeField] private GameObject _robotUI;
    [SerializeField] private GameObject _playerUI;

    [Header("Technical Variables")]
    private bool _controlMode;
    private float _timer;
    private Vector3 _nextPosition;
    private Vector3 _movingVector;
    private Vector2 _cameraRotation;

    private void Start() {

        _animator = GetComponent<Animator>();
        _movement = GetComponent<CharacterController>();
        _controller = MovingController.Instance;

    }

    private void Update() {

        if(!_controlMode) {

            Animations();
        }

        if(_controlMode) {
            CameraRotate();
            Animations();
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            ChangeMode();
        }

    }

    private void FixedUpdate() {

        if(!_controlMode) {
            _nextPosition = Vector3.Lerp(transform.position, _idlePosition.position, _movingSpeed / 10f);
            Timer();
            FollowPlayer();
        }

        if(_controlMode) {
            Move();
        }

    }

    private void FollowPlayer() {

        if(Vector3.Distance(transform.position, _nextPosition) < 0.02f) _timer = 0;

        if (_timer > 0.3f) {
            transform.position = Vector3.Lerp(transform.position, _idlePosition.position, _movingSpeed / 10f);

            transform.rotation = Quaternion.Lerp(transform.rotation, _idlePosition.rotation, 720f * Time.deltaTime);
        }

    }

    private void Animations() {

        if(!_controlMode) {
            if(Vector3.Distance(transform.position, _nextPosition) > 0.02f && _timer > 0.3f) _animator.SetTrigger("Move");
            else _animator.SetTrigger("Idle");
        } else _animator.SetTrigger("Idle");

    }

    private void Timer() {

        if(_timer < 0.3f) _timer += 1 * Time.deltaTime; 
        else if(Vector3.Distance(transform.position, _nextPosition) < 0.02f) _timer = 0;

    }

    private void ChangeMode() {

        if(_controller.IsDead) return;

        _controlMode = !_controlMode;
        _robotCamera.enabled = _controlMode;
        _playerCamera.enabled = !_controlMode;
        _controller.enabled = !_controlMode;
        _movement.enabled = _controlMode;
        _robotUI.SetActive(_controlMode);
        Cursor.visible = _controlMode;
        _playerUI.SetActive(!_controlMode);

    }

    private void Move() {

        _movingVector.x = Input.GetAxisRaw("Horizontal");
        _movingVector.z = Input.GetAxisRaw("Vertical");

        Vector3 movingDirection = transform.TransformDirection(Vector3.forward * 1.5f) * _movingVector.z + transform.TransformDirection(Vector3.right * 1.5f) * _movingVector.x;

        _movement.Move(movingDirection * Time.deltaTime * _movingSpeed * 2.5f);

    }

    private void CameraRotate() {
        _cameraRotation.x += Input.GetAxis("Mouse X") * 0.6f;
        _cameraRotation.y -= Input.GetAxis("Mouse Y");

        _cameraRotation.x = Mathf.Repeat(_cameraRotation.x, 360f);
        _cameraRotation.y = Mathf.Clamp(_cameraRotation.y, -30f, 30f);

        //robotCamera.transform.rotation = Quaternion.Euler(cameraRotation.y, 0f, 0f);
        transform.rotation = Quaternion.Euler(_cameraRotation.y, _cameraRotation.x, 0f);
    }

}
