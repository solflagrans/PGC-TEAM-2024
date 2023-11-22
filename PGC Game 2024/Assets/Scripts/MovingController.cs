using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    public float movingSpeed;
    public float jumpForce;
    public float doubleJumpForce;
    private Vector3 movingVector;

    private Rigidbody mc_rb;
    private bool canDoubleJump = false;
    private bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        mc_rb = gameObject.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        
        movingVector.x = Input.GetAxis("Horizontal");
        movingVector.z = Input.GetAxis("Vertical");
        mc_rb.MovePosition(mc_rb.position + movingVector * (movingSpeed * Time.deltaTime));
       if (Input.GetKeyDown(KeyCode.Space))
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

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
