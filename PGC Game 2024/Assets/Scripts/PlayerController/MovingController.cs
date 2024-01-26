using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovingController : MonoBehaviour
{

    [Header("Moving Mode")] public int movingMode = 0; //0 обынчный wasd, 1 - карабканье, 2 - полет между платформами, 3-управление роботом
    [Header("Audio")] 
    public AudioClip jumpSound;
    public AudioClip deathSound;
    [Header("Preferences")]
    public float movingSpeed;
    public float flyingSpeed;
    public float flyingDodgeSpeed;
    public float maxDodgeDeviation;
    public float jumpForce;
    public float doubleJumpForce;
    public float climbSpeed;
    
    [Header("Instances")]
    public LayerMask ground;
    public Transform jumpTime;
    private Rigidbody mc_rb;
    private Transform endClimbPoint;
    private Transform startClimbPoint;
    public Collider swordCollider;
    private PlayerInformation statistics;
    public CameraController cam;
    public Image diePanel;

    [Header("Techincal Variables")]
    [HideInInspector] public Vector3 movingVector;
    [HideInInspector] public bool isClimb;
    private bool canDoubleJump = false;
    [HideInInspector] public bool canJump;
    [HideInInspector] public bool isAttack;
    private bool waitAttack;
    [HideInInspector] public bool isDead;
    [HideInInspector] private bool isFlyingHorizontal = true;
    [HideInInspector] private Transform centerTransform;
    [HideInInspector] private float flyingDeviation = 0;
    public float[] mainRotations;


    void Start() {
        Cursor.visible = false;
        mc_rb = gameObject.GetComponent<Rigidbody>();
        statistics = gameObject.GetComponent<PlayerInformation>();

    }

    private void FixedUpdate() {

        if(isDead) return;

        if(movingMode == 0) Move();
        
        if(movingMode == 1) Climb();

        if (movingMode == 2) Fly();


    }

    void Update() {

        if(statistics.Hp <= 0) {
            isDead = true;
            Die();
        }

        if(isDead) return;

        if (movingMode != 2)
        {
            if (Input.GetButtonDown("Fire1") && !isAttack) Attack();

            canJump = Physics.Raycast(jumpTime.position, Vector3.down, 0.7f, ground);

            if (Input.GetKeyDown(KeyCode.Space) & !isClimb) Jump();
        }

    }

    //Ñîçäà¸ì äâèæåíèÿ ïåðñîíàæà ïî ãîðèçîíòàëè è âåðòèêàëè
    private void Move() {
        
        movingVector.x = Input.GetAxisRaw("Horizontal");
        movingVector.z = Input.GetAxisRaw("Vertical");
        movingVector = Quaternion.Euler(0,23f,0) * movingVector;
        mc_rb.MovePosition(mc_rb.position + movingVector.normalized * (movingSpeed * Time.deltaTime));

        if(Vector3.Normalize(movingVector) != Vector3.zero) {
            Quaternion lookRotation = Quaternion.LookRotation(movingVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 720 * Time.deltaTime);
        }

    }

    //Ïîçâîëÿåì åìó ïðûãàòü
    private void Jump() {

        if (canJump) {
            gameObject.GetComponent<Interactions>().PlaySound(jumpSound);
            mc_rb.AddForce(Vector3.up * (jumpForce * mc_rb.mass), ForceMode.Impulse);
            canDoubleJump = true;
        } 
        else if (canDoubleJump) {
            gameObject.GetComponent<Interactions>().PlaySound(jumpSound);
            mc_rb.AddForce(Vector3.up * (doubleJumpForce * mc_rb.mass), ForceMode.Impulse);
            canDoubleJump = false;
        }

    }

    private void Attack() {

        isAttack = true;
        swordCollider.enabled = true;

        StartCoroutine(StopAttack());

    }

    IEnumerator StopAttack() {

        if(!waitAttack) {
            waitAttack = true;
            yield return new WaitForSeconds(1f);
        }

        isAttack = false;
        swordCollider.enabled = false;
        waitAttack = false;

    }

    void OnTriggerEnter(Collider col) {

        if(col.CompareTag("Ladder")) {
            isClimb = true;
            movingMode = 1;
            endClimbPoint = col.transform.Find("EndPoint");
            startClimbPoint = col.transform.Find("StartPoint");
        }
        if(col.CompareTag("Platform"))
        {
            mc_rb.useGravity = true;
            mc_rb.constraints = RigidbodyConstraints.None;
            mc_rb.constraints = RigidbodyConstraints.FreezeRotation;
            movingMode = 0;
        }

    }

    private void OnTriggerExit(Collider col) {

        if(col.CompareTag("Ladder")) {
            isClimb = false;
            movingMode = 0;
            mc_rb.useGravity = true;
        }
        if(col.CompareTag("Platform"))
        {
            gameObject.transform.position += new Vector3(0, 1, 0);
            centerTransform = gameObject.transform;
            movingMode = 2;
            flyingDeviation = 0;
            isFlyingHorizontal = (transform.eulerAngles.y + 10 >= mainRotations[2] &&
                                  transform.eulerAngles.y - 10 <= mainRotations[2]) ||
                                 (transform.eulerAngles.y + 10 >= mainRotations[3] && transform.eulerAngles.y - 10 <= mainRotations[3]);
        }
    }

    private void Climb() {

        movingVector.x = Input.GetAxisRaw("Horizontal");
        movingVector.z = Input.GetAxisRaw("Vertical");

        if(movingVector.z > 0.05f) transform.position = Vector3.MoveTowards(transform.position, endClimbPoint.position, climbSpeed/100f);
        else if(movingVector.z < -0.05f) transform.position = Vector3.MoveTowards(transform.position, startClimbPoint.position, climbSpeed/100f);

        Quaternion rotateTo = Quaternion.RotateTowards(transform.rotation, startClimbPoint.rotation, 720f);
        transform.rotation = new Quaternion(transform.rotation.x, rotateTo.y, transform.rotation.z, transform.rotation.w);

        mc_rb.useGravity = false;

        transform.position = new Vector3(movingVector.x * movingSpeed * Time.deltaTime + transform.position.x, transform.position.y, transform.position.z);

    }
    private void Fly()
    {
        mc_rb.constraints = RigidbodyConstraints.FreezePositionY;

        print(flyingDeviation);
        movingVector += new Vector3(centerTransform.forward.x*flyingSpeed, 0, centerTransform.forward.z*flyingSpeed);

        if (isFlyingHorizontal)
        {
            
            if (Input.GetKey(KeyCode.W) && flyingDeviation < maxDodgeDeviation)
            {
                movingVector += new Vector3(0, 0, flyingDodgeSpeed);
                flyingDeviation += flyingDodgeSpeed;

            }

            if (Input.GetKey(KeyCode.S) && flyingDeviation > -maxDodgeDeviation)
            {
                movingVector -= new Vector3(0, 0, flyingDodgeSpeed);

                flyingDeviation -= flyingDodgeSpeed;

            }
        }
        else 
        {

            if (Input.GetKey(KeyCode.A) && flyingDeviation > -maxDodgeDeviation)
            {
                movingVector -= new Vector3(flyingDodgeSpeed, 0, 0);

                flyingDeviation -= flyingDodgeSpeed;

            }

            if (Input.GetKey(KeyCode.D) && flyingDeviation < maxDodgeDeviation)
            {
                movingVector += new Vector3(flyingDodgeSpeed, 0, 0);
                flyingDeviation += flyingDodgeSpeed;
            }
        }
        
        mc_rb.MovePosition(mc_rb.position + movingVector* (movingSpeed * Time.deltaTime));
}
    

    private void Die() {

        transform.position = Vector3.MoveTowards(transform.position, Vector3.down * 5f, 0.08f);

        cam.enabled = false;

        diePanel.fillAmount += 1 * Time.deltaTime;

        gameObject.GetComponent<Interactions>().PlaySound(deathSound);
        
        print("Вы умерли");

    }
}


