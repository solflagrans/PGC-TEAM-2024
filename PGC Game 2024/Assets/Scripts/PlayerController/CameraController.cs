using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Preferences")]
    [SerializeField] private Vector3 _locOffset;

    [Header("Instances")]
    private Transform _player;

    private void Start() {

        _player = MovingController.Instance.transform;

    }

    private void FixedUpdate() {

        FollowPlayer();

    }

    private void FollowPlayer() {

        Vector3 desiredPosition = new Vector3(_player.position.x/2, _player.position.y, _player.position.z/2) + _locOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.125f);
        transform.position = smoothedPosition;

    }

}
