using System.Collections;
using UnityEngine;

public class Modificators : MonoBehaviour
{
    //Re-write for singleton movingcontroller and abstart modificator class

    [SerializeField] private float _time;

    private MovingController _controller;

    [Header("Techincal Variables")]
    private bool _inSpeed;
    private bool _timeUp;
    private bool _timeDown;
    private bool _inJump;

    private void Start() {

        _controller = MovingController.Instance;

    }

    private void OnTriggerEnter(Collider col) {

        if(col.CompareTag("SpeedSphere")) StartCoroutine(GiveSpeed(_time, col.gameObject));
        if(col.CompareTag("TimeUpSphere")) StartCoroutine(SpeedUpTime(_time, col.gameObject));
        if(col.CompareTag("TimeDownSphere")) StartCoroutine(SpeedDownTime(_time, col.gameObject));
        if(col.CompareTag("JumpBoostSphere")) StartCoroutine(JumpBoost(_time, col.gameObject));

    }

    IEnumerator GiveSpeed(float time, GameObject sphere) {

        if(!_inSpeed) {
            _inSpeed = true;
            _controller.MovingSpeed = _controller.MovingSpeed * 2.5f;
            Destroy(sphere);

            yield return new WaitForSeconds(time);
        }

        _controller.MovingSpeed = _controller.MovingSpeed / 2.5f;
        _inSpeed = false;

    }

    IEnumerator SpeedUpTime(float time, GameObject sphere) {

        if(!_timeUp) {
            _timeUp = true;
            Time.timeScale = 2f;
            Destroy(sphere);

            yield return new WaitForSeconds(time);
        }

        Time.timeScale = 1f;
        _timeUp = false;

    }

    IEnumerator SpeedDownTime(float time, GameObject sphere) {

        if(!_timeDown) {
            _timeDown = true;
            Time.timeScale = 0.5f;
            Destroy(sphere);

            yield return new WaitForSeconds(time);
        }

        Time.timeScale = 1f;
        _timeDown = false;

    }

    IEnumerator JumpBoost(float time, GameObject sphere) {

        if(!_inJump) {
            _inJump = true;
            _controller.JumpForce = _controller.JumpForce * 2;
            _controller.DoubleJumpForce = _controller.DoubleJumpForce * 2;
            Destroy(sphere);

            yield return new WaitForSeconds(time);
        }

        _controller.JumpForce = _controller.JumpForce / 2;
        _controller.DoubleJumpForce = _controller.DoubleJumpForce / 2;
        _inJump = false;

    }

}
