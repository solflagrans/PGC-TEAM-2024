using UnityEngine;

public class PlayerVisual : MonoBehaviour
{

    private MovingController controller;
    private Animator animator;
    private Rigidbody rigid;

    void Start()
    {

        controller = GetComponent<MovingController>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if(controller.isClimb && controller.movingVector.normalized != Vector3.zero) animator.SetTrigger("Climb");
        else if(rigid.velocity.y > 0.005f || rigid.velocity.y < -0.005f) animator.SetTrigger("Jump");
        else if(controller.movingVector.normalized != Vector3.zero) animator.SetTrigger("Run");
        else if(controller.isClimb) animator.SetTrigger("ClimbIdle");
        else animator.SetTrigger("Idle");

    }
}
