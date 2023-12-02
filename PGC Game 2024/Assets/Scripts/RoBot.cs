using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoBot : MonoBehaviour
{

    [Header("Preferences")]
    public float movingSpeed;

    [Header("Instances")]
    public Transform idlePosition;
    private Animator animator;

    private void Start() {

        animator = GetComponent<Animator>();

    }

    private void Update() {

        Animations();

    }

    private void FixedUpdate() {

        Move();

    }

    private void Move() {

        transform.position = Vector3.Lerp(transform.position, idlePosition.position, movingSpeed / 10f);

        transform.rotation = Quaternion.Lerp(transform.rotation, idlePosition.rotation, 720f * Time.deltaTime);

    }

    private void Animations() {

        Vector3 nextPositon = Vector3.Lerp(transform.position, idlePosition.position, movingSpeed / 10f);

        if(Vector3.Distance(transform.position, nextPositon) > 0.03f) animator.SetTrigger("Move");
        else animator.SetTrigger("Idle");

    }

}
