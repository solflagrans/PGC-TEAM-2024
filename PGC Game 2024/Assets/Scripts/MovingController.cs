using UnityEngine;

public class MovingController : MonoBehaviour
{

    [Header("Preferences")]
    public float movingSpeed;
    public float jumpForce;
    public float doubleJumpForce;
    
    [Header("Instances")]
    public LayerMask ground;
    public Transform jumpTime;
    private Rigidbody mc_rb;
    private Animator animator;

    [Header("Techincal Variables")]
    public Vector3 movingVector;
    private bool canDoubleJump = false;
    private bool canJump;


    void Start() {

        mc_rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    private void FixedUpdate() {

        Move();

    }

    void Update() {

        canJump = Physics.Raycast(jumpTime.position, Vector3.down, 0.7f, ground);

        if(Input.GetKeyDown(KeyCode.Space)) Jump();

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
}


