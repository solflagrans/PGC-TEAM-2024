using UnityEngine;

public class PlayerVisual : MonoBehaviour
{

    private MovingController controller;
    private Animator animator;
    private Rigidbody rigid;

    public GameObject sword;

    void Start()
    {

        controller = GetComponent<MovingController>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if(controller.enabled) {
            if(Input.GetButtonDown("Fire1") && !controller.isAttack) animator.SetTrigger("Attack");
            if(controller.isClimb && controller.movingVector.normalized != Vector3.zero) animator.SetTrigger("Climb");
            else if((rigid.velocity.y > 0.05f || rigid.velocity.y < -0.05f) && !controller.canJump) animator.SetTrigger("Jump");
            else if(controller.movingVector.normalized != Vector3.zero) animator.SetTrigger("Run");
            else if(controller.isClimb) animator.SetTrigger("ClimbIdle");
            else animator.SetTrigger("Idle");

            if(controller.isClimb) sword.SetActive(false);
            else sword.SetActive(true);
        } else animator.SetTrigger("Idle");

    }
}
