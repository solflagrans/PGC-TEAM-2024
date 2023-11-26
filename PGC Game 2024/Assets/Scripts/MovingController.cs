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

    [Header("Techincal Variables")]
    private Vector3 movingVector;
    private bool canDoubleJump = false;
    private bool canJump ;

    void Start() {

        mc_rb = gameObject.GetComponent<Rigidbody>();

    }

    void Update()
    {

        canJump = Physics.Raycast(transform.position, Vector3.down, 1.2f, Ground);
        
        Move();

       if (Input.GetKeyDown(KeyCode.Space))
       {

        Jump();

       }

    }

    //Ñîçäà¸ì äâèæåíèÿ ïåðñîíàæà ïî ãîðèçîíòàëè è âåðòèêàëè
    private void Move() 
    {
        
        movingVector.x = Input.GetAxis("Horizontal");
        movingVector.z = Input.GetAxis("Vertical");

        mc_rb.MovePosition(mc_rb.position + movingVector * movingSpeed * Time.deltaTime);

    }

    //Ïîçâîëÿåì åìó ïðûãàòü
    private void Jump() 
    {
        if (canJump) 
        {
                   mc_rb.velocity = new Vector3(mc_rb.velocity.x, jumpForce, mc_rb.velocity.z);
                   canJump = false;
                   canDoubleJump = true;
        }
        else if (canDoubleJump)
        {
                   mc_rb.velocity = new Vector3(mc_rb.velocity.x, doubleJumpForce, mc_rb.velocity.z);
                   canDoubleJump = false;
        }
    }
}


