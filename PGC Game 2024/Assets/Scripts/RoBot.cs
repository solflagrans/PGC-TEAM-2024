using UnityEngine;

public class RoBot : MonoBehaviour
{

    [Header("Preferences")]
    public float movingSpeed;
    private bool controlMode;

    [Header("Instances")]
    public Transform idlePosition;
    private Animator animator;
    public Camera playerCamera;
    public Camera robotCamera;
    public MovingController controller;
    private Rigidbody rigid;

    [Header("Technical Variables")]
    private float timer;
    private Vector3 nextPosition;
    private Vector3 movingVector;
    private Vector2 cameraRotation;

    private void Start() {

        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();

    }

    private void Update() {

        if(!controlMode) {
            nextPosition = Vector3.Lerp(transform.position, idlePosition.position, movingSpeed / 10f);

            Timer();

            Animations();
        }

        if(controlMode) {
            CameraRotate();
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            ChangeMode();
        }

    }

    private void FixedUpdate() {

        if(!controlMode) {
            FollowPlayer();
        }

        if(controlMode) {
            Move();
        }

    }

    private void FollowPlayer() {

        if(Vector3.Distance(transform.position, nextPosition) < 0.02f) timer = 0;

        if (timer > 0.3f) {
            transform.position = Vector3.Lerp(transform.position, idlePosition.position, movingSpeed / 10f);

            transform.rotation = Quaternion.Lerp(transform.rotation, idlePosition.rotation, 720f * Time.deltaTime);
        }

    }

    private void Animations() {

        if(Vector3.Distance(transform.position, nextPosition) > 0.02f && timer > 0.3f) animator.SetTrigger("Move");
        else animator.SetTrigger("Idle");

    }

    private void Timer() {

        if(timer < 0.3f) timer += 1 * Time.deltaTime; 
        else if(Vector3.Distance(transform.position, nextPosition) < 0.02f) timer = 0;

    }

    private void ChangeMode() {
        controlMode = !controlMode;
        controller.enabled = !controlMode;

        if(controlMode) {
            robotCamera.enabled = true;
            playerCamera.enabled = false;
        } else {
            robotCamera.enabled = false;
            playerCamera.enabled = true;
        }

    }

    private void Move() {

        movingVector.x = Input.GetAxisRaw("Horizontal");
        movingVector.z = Input.GetAxisRaw("Vertical");

        //Vector3 movingDirection = new Vector3(movingVector.x + cameraRotation.x, movingVector.z + cameraRotation.y, movingVector.z);
        rigid.MoveRotation(Quaternion.Euler(cameraRotation * Time.deltaTime) * rigid.rotation);
        print(Quaternion.Euler(cameraRotation * Time.deltaTime));
        rigid.MovePosition(movingVector * movingSpeed * 3 * Time.deltaTime + rigid.position);

    }

    private void CameraRotate() {
        cameraRotation.x += Input.GetAxis("Mouse X");
        cameraRotation.y -= Input.GetAxis("Mouse Y");

        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -30f, 30f);
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -30f, 30f);

        robotCamera.transform.rotation = Quaternion.Euler(cameraRotation.y, cameraRotation.x, 0f);
        //transform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, 0f);
    }

}
