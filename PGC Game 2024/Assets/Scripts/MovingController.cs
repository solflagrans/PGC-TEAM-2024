using UnityEngine;

public class MovingController : MonoBehaviour
{

    [Header("Preferences")]
    public float movingSpeed;
    public float jumpForce;
    public float doubleJumpForce;
    
    [Header("Instances")]
    public LayerMask Ground;
    private Rigidbody mc_rb;
    private Animator animator;

    [Header("Techincal Variables")]
    private Vector3 movingVector;
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

        canJump = Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Vector3.down, 1.2f, Ground);

       if (Input.GetKeyDown(KeyCode.Space)) {

            Jump();

       }

    }

    //Ñîçäà¸ì äâèæåíèÿ ïåðñîíàæà ïî ãîðèçîíòàëè è âåðòèêàëè
    private void Move() {
        
        movingVector.x = Input.GetAxisRaw("Horizontal");
        movingVector.z = Input.GetAxisRaw("Vertical");

        mc_rb.MovePosition(mc_rb.position + movingVector.normalized * movingSpeed * Time.deltaTime);

        if(Vector3.Normalize(movingVector) != Vector3.zero && mc_rb.velocity.y < 0.004f) {
            animator.SetTrigger("Run");
        } else if (mc_rb.velocity.y < 0.004f) animator.SetTrigger("Idle");

        if(Vector3.Normalize(movingVector) != Vector3.zero) {
            Quaternion lookRotation = Quaternion.LookRotation(movingVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 720 * Time.deltaTime);
        }

    }

    //Ïîçâîëÿåì åìó ïðûãàòü
    private void Jump() {
        if (canJump) {
            mc_rb.AddForce(Vector3.up * jumpForce * mc_rb.mass, ForceMode.Impulse);
            canJump = false;
            canDoubleJump = true;
            animator.SetTrigger("Jump");
        }
        else if (canDoubleJump) {
            mc_rb.AddForce(Vector3.up * doubleJumpForce * mc_rb.mass, ForceMode.Impulse);
            canDoubleJump = false;
            animator.SetTrigger("Jump");
        }
    }
}


