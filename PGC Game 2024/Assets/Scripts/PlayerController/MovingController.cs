using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovingController : MonoBehaviour
{

    public static MovingController Instance { get; private set; }

    public float MovingSpeed { get => _movingSpeed; set { if(value > 0 && value < 100) _movingSpeed = value; } }
    public float JumpForce { get => _jumpForce; set { if(value > 0 && value < 100) _jumpForce = value; } }
    public float DoubleJumpForce { get => _doubleJumpForce; set { if(value > _jumpForce && value < 100) _doubleJumpForce = value; } }
    public bool IsDead { get => _isDead; }
    public string MovingMode { 
        get => _movingMode; 
        set {
            if(value == "Default" || value == "Climbing" || value == "Flying") _movingMode = value;
            else print("Wrong moving mode");
        } 
    }
    public bool IsAttack { get => _isAttack; set => _isAttack = value; }
    public Vector3 MovingVector { get => _movingVector; set => _movingVector = value; }

    [Header("Moving Mode")] 
    private string _movingMode = "Default"; //Default, Climbing, Flying

    [Header("Audio")]
    private AudioHandler _audioHandler;

    [Header("Preferences")]
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _flyingSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _doubleJumpForce;
    [SerializeField] private float _climbSpeed;
    
    [Header("Instances")]
    [SerializeField] private LayerMask _ground;
    [SerializeField] private Transform _jumpTime;
    private Rigidbody _rigidbody;
    private Transform _endClimbPoint;
    private Transform _startClimbPoint;
    [SerializeField] private Collider _swordCollider;
    [SerializeField] private CameraController _cam;
    [SerializeField] private Image _diePanel;

    [Header("Techincal Variables")]
    private Vector3 _movingVector;
    private bool _canDoubleJump;
    private bool _canJump;
    private bool _isAttack;
    private bool _waitAttack;
    private bool _isDead;
    private bool _deadSoundPlayed;
    private bool isFlyingHorizontal = true;
    private Transform centerTransform;

    private void Awake() {

        if(!Instance) Instance = this;

    }

    void Start() {

        Cursor.visible = false;

        _rigidbody = GetComponent<Rigidbody>();
        _audioHandler = AudioHandler.Instance;

    }

    private void FixedUpdate() {

        if(_isDead) return;

        switch(_movingMode) {
            case "Default":
                Move();
                break;
            case "Climbing":
                Climb();
                break;
            case "Flying":
                Fly();
                break;
        }

    }

    void Update() {

        if(PlayerInformation.Instance.Hp <= 0) {
            _isDead = true;
            Die();
        }

        if(_isDead) return;

        if (_movingMode == "Default")
        {
            if (Input.GetButtonDown("Fire1") && !_isAttack) Attack();

            _canJump = Physics.Raycast(_jumpTime.position, Vector3.down, 0.7f, _ground);

            if (Input.GetKeyDown(KeyCode.Space)) Jump();
        }

    }

    private void Move() {
        
        _movingVector.x = Input.GetAxisRaw("Horizontal");
        _movingVector.z = Input.GetAxisRaw("Vertical");
        _movingVector = Quaternion.Euler(0f, 45f, 0f) * _movingVector;
        _rigidbody.MovePosition(_rigidbody.position + _movingVector.normalized * (_movingSpeed * Time.deltaTime));

        if(Vector3.Normalize(_movingVector) != Vector3.zero) {
            Quaternion lookRotation = Quaternion.LookRotation(_movingVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 900 * Time.deltaTime);
            if(!_audioHandler._moveStateSource.isPlaying & _canJump) _audioHandler._moveStateSource.PlayOneShot(_audioHandler._walkSound);
        } else {
            if(_audioHandler._moveStateSource.isPlaying) _audioHandler._moveStateSource.Stop();
        }

        if(!_canJump) _audioHandler._moveStateSource.Stop();

    }

    private void Jump() {

        if(_canJump) {
            _audioHandler._jumpSource.PlayOneShot(_audioHandler._jumpSound);
            _rigidbody.AddForce(Vector3.up * (_jumpForce * _rigidbody.mass), ForceMode.Impulse);
            _canDoubleJump = true;
        } 
        else if(_canDoubleJump) {
            _audioHandler._jumpSource.PlayOneShot(_audioHandler._jumpSound);
            _rigidbody.AddForce(Vector3.up * (_doubleJumpForce * _rigidbody.mass), ForceMode.Impulse);
            _canDoubleJump = false;
        }

    }

    private void Attack() {

        _isAttack = true;
        _swordCollider.enabled = true;

        _audioHandler._swordSource.PlayOneShot(_audioHandler._swingSound);

        StartCoroutine(StopAttack());

    }

    IEnumerator StopAttack() {

        if(!_waitAttack) {
            _waitAttack = true;
            yield return new WaitForSeconds(1f);
        }

        _isAttack = false;
        _swordCollider.enabled = false;
        _waitAttack = false;

    }

    void OnTriggerEnter(Collider col) {

        if(col.CompareTag("Ladder")) {
            _endClimbPoint = col.transform.Find("EndPoint");
            _startClimbPoint = col.transform.Find("StartPoint");
            _movingMode = "Climbing";
        }

        if(col.CompareTag("Platform"))
        {
            _rigidbody.useGravity = true;
            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            _movingMode = "Default";
        }

    }

    private void OnTriggerExit(Collider col) {

        if(col.CompareTag("Ladder")) {
            _movingMode = "Default";
            _rigidbody.useGravity = true;
        }
        if(col.CompareTag("Platform"))
        {
            gameObject.transform.position += new Vector3(0, 1, 0);
            centerTransform = gameObject.transform;
            _movingMode = "Flying";
        }
    }

    private void Climb() {

        _movingVector.x = Input.GetAxisRaw("Horizontal");
        _movingVector.z = Input.GetAxisRaw("Vertical");

        if(_movingVector.z > 0.05f) transform.position = Vector3.MoveTowards(transform.position, _endClimbPoint.position, _climbSpeed/100f);
        else if(_movingVector.z < -0.05f) transform.position = Vector3.MoveTowards(transform.position, _startClimbPoint.position, _climbSpeed/100f);

        Quaternion rotateTo = Quaternion.RotateTowards(transform.rotation, _startClimbPoint.rotation, 720f);
        transform.rotation = new Quaternion(transform.rotation.x, rotateTo.y, transform.rotation.z, transform.rotation.w);

        _rigidbody.useGravity = false;

        transform.position = new Vector3(_movingVector.x * _movingSpeed * Time.deltaTime + transform.position.x, transform.position.y, transform.position.z);

    }
    private void Fly()
    {

        _rigidbody.constraints = RigidbodyConstraints.FreezePositionY;

        _movingVector += new Vector3(centerTransform.forward.x, 0, centerTransform.forward.z);

        if (isFlyingHorizontal) {
            if (Input.GetKey(KeyCode.W)) {
                _movingVector += new Vector3(0, 0, _flyingSpeed);
            }
            if (Input.GetKey(KeyCode.S)) {
                _movingVector -= new Vector3(0, 0, _flyingSpeed);
            }
        } else {
            if (Input.GetKey(KeyCode.A)) {
                _movingVector -= new Vector3(_flyingSpeed, 0, 0);
            }
            if (Input.GetKey(KeyCode.D)) {
                _movingVector += new Vector3(_flyingSpeed, 0, 0);
            }
        }

        _rigidbody.MovePosition(_rigidbody.position + _movingVector * (_movingSpeed * Time.deltaTime));

    }

    private void Die() {

        transform.position = Vector3.MoveTowards(transform.position, Vector3.down * 5f, 0.08f);

        _cam.enabled = false;

        _diePanel.fillAmount += 1 * Time.deltaTime;

        if(!_audioHandler._gameStateSource.isPlaying && !_deadSoundPlayed) {
            _audioHandler._gameStateSource.PlayOneShot(_audioHandler._deathSound);
            _deadSoundPlayed = true;
        }
        
    }
}


