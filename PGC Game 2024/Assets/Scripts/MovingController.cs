using UnityEngine;

public class MovingController : MonoBehaviour
{
    [Header("Preferences")]
    public float movingSpeed;
    public float jumpForce;

    [Header("Instances")]
    public LayerMask Ground;
    private Rigidbody mc_rb;

    [Header("Techincal Variables")]
    private Vector3 movingVector;
    private bool canDoubleJump = false;
    private bool canJump;

    void Start()
    {
        mc_rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {

        canJump = Physics.Raycast(transform.position, Vector3.down, 1.2f, Ground);

        print(canJump);

        Move();

       if (Input.GetKeyDown(KeyCode.Space))
       {

        Jump();

       }

    }

    //Создаём движения персонажа по горизонтали и вертикали
    private void Move() 
    {
        
        movingVector.x = Input.GetAxis("Horizontal");
        movingVector.z = Input.GetAxis("Vertical");

        mc_rb.MovePosition(mc_rb.position + movingVector * (movingSpeed * Time.deltaTime));

    }

    //Позволяем ему прыгать
    private void Jump() 
    {
           if (canJump || canDoubleJump)
           {

               mc_rb.velocity = new Vector3(mc_rb.velocity.x, jumpForce, mc_rb.velocity.z);
               canDoubleJump = !canDoubleJump;

           }
    }
}
