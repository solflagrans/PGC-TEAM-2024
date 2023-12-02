using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MovingController : MonoBehaviour
{

    [Header("Preferences")]
    public float movingSpeed;
    public float jumpForce;
    public float doubleJumpForce;
    public float climbSpeed;
    
    [Header("Instances")]
    public LayerMask ground;
    public Transform jumpTime;
    private Rigidbody mc_rb;
    private Transform endClimbPoint;
    private Transform startClimbPoint;

    [Header("Techincal Variables")]
    [HideInInspector] public Vector3 movingVector;
    [HideInInspector] public bool isClimb;
    private bool canDoubleJump = false;
    private bool canJump;


    void Start() {

        mc_rb = gameObject.GetComponent<Rigidbody>();

    }

    private void FixedUpdate() {

        if(isClimb) Climb();

        if(!isClimb) Move();

    }

    void Update() {

        canJump = Physics.Raycast(jumpTime.position, Vector3.down, 0.7f, ground);

        if(Input.GetKeyDown(KeyCode.Space) & !isClimb) Jump();

    }

    //Ñîçäà¸ì äâèæåíèÿ ïåðñîíàæà ïî ãîðèçîíòàëè è âåðòèêàëè
    private void Move() {
        
        movingVector.x = Input.GetAxisRaw("Horizontal");
        movingVector.z = Input.GetAxisRaw("Vertical");

        mc_rb.MovePosition(mc_rb.position + movingVector.normalized * movingSpeed * Time.deltaTime);

        if(Vector3.Normalize(movingVector) != Vector3.zero) {
            Quaternion lookRotation = Quaternion.LookRotation(movingVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 720 * Time.deltaTime);
        }

    }

    //Ïîçâîëÿåì åìó ïðûãàòü
    private void Jump() {

        if (canJump) {
            mc_rb.AddForce(Vector3.up * jumpForce * mc_rb.mass, ForceMode.Impulse);
            canDoubleJump = true;
        } else if (canDoubleJump) {
            mc_rb.AddForce(Vector3.up * doubleJumpForce * mc_rb.mass, ForceMode.Impulse);
            canDoubleJump = false;
        }

    }

    void OnTriggerEnter(Collider col) {

        if(col.CompareTag("Ladder")) {
            isClimb = true;
            endClimbPoint = col.transform.Find("EndPoint");
            startClimbPoint = col.transform.Find("StartPoint");
        }

    }

    private void OnTriggerExit(Collider col) {

        if(col.CompareTag("Ladder")) {
            isClimb = false;
            mc_rb.useGravity = true;
        }

    }

    private void Climb() {

        movingVector.x = Input.GetAxisRaw("Horizontal");
        movingVector.z = Input.GetAxisRaw("Vertical");

        if(movingVector.z > 0.05f) transform.position = Vector3.MoveTowards(transform.position, endClimbPoint.position, climbSpeed/100f);
        else if(movingVector.z < -0.05f) transform.position = Vector3.MoveTowards(transform.position, startClimbPoint.position, climbSpeed/100f);

        Quaternion rotateTo = Quaternion.RotateTowards(transform.rotation, startClimbPoint.rotation, 720f);
        transform.rotation = new Quaternion(transform.rotation.x, rotateTo.y, transform.rotation.z, transform.rotation.w);

        mc_rb.useGravity = false;

        transform.position = new Vector3(movingVector.x * movingSpeed * Time.deltaTime + transform.position.x, transform.position.y, transform.position.z);

    }
}


