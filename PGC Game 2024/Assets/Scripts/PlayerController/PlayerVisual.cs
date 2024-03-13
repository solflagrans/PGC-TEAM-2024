using UnityEngine;

public class PlayerVisual : MonoBehaviour
{

    private MovingController _controller;
    private Animator animator;
    private Rigidbody rigid;
    [SerializeField] private GameObject sword;

    void Start()
    {

        _controller = MovingController.Instance;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if(_controller.enabled) {

            if (Input.GetButtonDown("Fire1") && !_controller.IsAttack)
            {
                animator.SetTrigger("Attack");
            }

            if(_controller.MovingMode == "Climbing" && _controller.MovingVector.normalized != Vector3.zero) 
            {
                animator.SetTrigger("Climb");
            } else if(_controller.MovingMode == "Flying")
            {
                animator.SetTrigger("Jump");
            } else if(rigid.velocity.y > 0.005f || rigid.velocity.y < -0.005f) 
            {
                animator.SetTrigger("Jump");
            } else if(_controller.MovingVector.normalized != Vector3.zero) 
            {
                animator.SetTrigger("Run");
            } else if(_controller.MovingMode == "Climbing") animator.SetTrigger("ClimbIdle");
            else animator.SetTrigger("Idle");
            if(_controller.MovingMode == "Climbing") sword.SetActive(false);
            else sword.SetActive(true);
        } else animator.SetTrigger("Idle");

    }
}
