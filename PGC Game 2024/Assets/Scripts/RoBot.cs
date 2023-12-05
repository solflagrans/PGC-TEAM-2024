using UnityEngine;

public class RoBot : MonoBehaviour
{

    [Header("Preferences")]
    public float movingSpeed;

    [Header("Instances")]
    public Transform idlePosition;
    private Animator animator;

    [Header("Technical Variables")]
    private float timer;
    private Vector3 nextPosition;

    private void Start() {

        animator = GetComponent<Animator>();

    }

    private void Update() {

        nextPosition = Vector3.Lerp(transform.position, idlePosition.position, movingSpeed / 10f);

        Timer();

        Animations();

    }

    private void FixedUpdate() {

        Move();

    }

    private void Move() {

        if(Vector3.Distance(transform.position, nextPosition) < 0.02f) timer = 0;

        if (timer > 0.3f) {
            transform.position = Vector3.Lerp(transform.position, idlePosition.position, movingSpeed / 10f);

            transform.rotation = Quaternion.Lerp(transform.rotation, idlePosition.rotation, 720f * Time.deltaTime);
        }

    }

    private void Animations() {

        if(Vector3.Distance(transform.position, nextPosition) > 0.02f && timer > 0.3f) animator.SetTrigger("Move");
        else animator.SetTrigger("Idle");

    }

    private void Timer() {

        if(timer < 0.3f) timer += 1 * Time.deltaTime; 
        else if(Vector3.Distance(transform.position, nextPosition) < 0.02f) timer = 0;

    }

}
