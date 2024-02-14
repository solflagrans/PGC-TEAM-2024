using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modificators : MonoBehaviour
{

    public float time;
    private MovingController controller;

    [Header("Techincal Variables")]
    private bool inSpeed = false;
    [HideInInspector] public bool timeUp = false;
    [HideInInspector] public bool timeDown = false;
    private bool inJump = false;

    private void Start() {
        controller = GetComponent<MovingController>();
    }

    private void OnTriggerEnter(Collider col) {

        if(col.CompareTag("SpeedSphere")) StartCoroutine(GiveSpeed(time, col.gameObject));
        if(col.CompareTag("TimeUpSphere")) StartCoroutine(SpeedUpTime(time, col.gameObject));
        if(col.CompareTag("TimeDownSphere")) StartCoroutine(SpeedDownTime(time, col.gameObject));
        if(col.CompareTag("JumpBoostSphere")) StartCoroutine(JumpBoost(time, col.gameObject));

    }

    IEnumerator GiveSpeed(float time, GameObject sphere) {

        if(!inSpeed) {
            inSpeed = true;
            controller.movingSpeed = controller.movingSpeed * 2.5f;
            Destroy(sphere);

            yield return new WaitForSeconds(time);
        }

        controller.movingSpeed = controller.movingSpeed / 2.5f;
        inSpeed = false;

    }

    IEnumerator SpeedUpTime(float time, GameObject sphere) {

        if(!timeUp) {
            timeUp = true;
            Time.timeScale = 2f;
            Destroy(sphere);

            yield return new WaitForSeconds(time);
        }

        Time.timeScale = 1f;
        timeUp = false;

    }

    IEnumerator SpeedDownTime(float time, GameObject sphere) {

        if(!timeDown) {
            timeDown = true;
            Time.timeScale = 0.5f;
            Destroy(sphere);

            yield return new WaitForSeconds(time);
        }

        Time.timeScale = 1f;
        timeDown = false;

    }

    IEnumerator JumpBoost(float time, GameObject sphere) {

        if(!inJump) {
            inJump = true;
            controller.jumpForce = controller.jumpForce * 2;
            controller.doubleJumpForce = controller.doubleJumpForce * 2;
            Destroy(sphere);

            yield return new WaitForSeconds(time);
        }

        controller.jumpForce = controller.jumpForce / 2;
        controller.doubleJumpForce = controller.doubleJumpForce / 2;
        inJump = false;

    }

}
