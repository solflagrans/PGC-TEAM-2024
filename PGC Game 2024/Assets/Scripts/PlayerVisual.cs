using UnityEngine;

public class PlayerVisual : MonoBehaviour
{

    private Animator animator;
    private Rigidbody rigid;

    void Start()
    {

        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();

    }

    void Update()
    {

        if(rigid.velocity.x > 0 | rigid.velocity.z > 0) animator.SetTrigger("Run");
        else if(rigid.velocity.y > 0) animator.SetTrigger("Jump");
        else animator.SetTrigger("Idle");

    }
}
