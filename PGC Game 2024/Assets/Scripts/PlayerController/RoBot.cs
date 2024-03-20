using Unity.VisualScripting;
using UnityEngine;

public class RoBot : MonoBehaviour
{

    [Header("Preferences")]
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _upSpeed;

    [Header("Instances")]
    [SerializeField] private Transform _idlePosition;
    private Animator _animator;
    private MovingController _controller;
    private CharacterController _movement;
    [SerializeField] private Camera _cam;

    [Header("Technical Variables")]
    private float _timer;
    private bool _controlMode;
    private Vector3 _nextPosition;
    private Vector3 _movingVector;

    private void Start() {

        _animator = GetComponent<Animator>();
        _movement = GetComponent<CharacterController>();

        _controller = MovingController.Instance;

    }

    private void Update() {

        Animations();

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
            Check();
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
        _controller.enabled = !_controlMode;

        AudioHandler.Instance.robotSource.Stop();

    }

    void Check() {

        Vector3 point = _cam.WorldToViewportPoint(transform.position);
        if (point.y < 0f )
        {
            transform.position += new Vector3(0, 0.1f, 0);
        } 
        if ( point.y > 1f)
        {
            transform.position -= new Vector3(0, 0.1f, 0);
        } 
        if ( point.x > 1f)
        {
            transform.position -= new Vector3(0.1f, 0, 0);
        } 
        if ( point.x < 0f)
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }

    }

    private void Move() {

        _movingVector.x = Input.GetAxisRaw("Horizontal");
        _movingVector.z = Input.GetAxisRaw("Vertical");
        _movingVector = Quaternion.Euler(0, 45f, 0) * _movingVector;
        Vector3 movingDirection = new Vector3(_movingVector.x, 0f, _movingVector.z);

        if (Input.GetKey(KeyCode.Q))
        {
            movingDirection += new Vector3(0, _upSpeed, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            movingDirection -= new Vector3(0, _upSpeed, 0);
        }

        _movement.Move(movingDirection * (Time.deltaTime * _movingSpeed * 2.5f));

        if(Vector3.Normalize(_movingVector) != Vector3.zero) {
            Quaternion lookRotation = Quaternion.LookRotation(_movingVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 900 * Time.deltaTime);
        }

        if(!AudioHandler.Instance.robotSource.isPlaying) AudioHandler.Instance.robotSource.PlayOneShot(AudioHandler.Instance.helicopterSound);

    }

}
