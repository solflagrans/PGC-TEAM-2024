using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Preferences")]
    [SerializeField] private Vector3 _locOffset;
    [SerializeField, Range(1, 3)] private float _sensitivity;

    [Header("Instances")]
    private Transform _player;

    public float Sensitivity { get => _sensitivity; set => _sensitivity = value; }

    private void Start() {

        _player = MovingController.Instance.transform;

    }

    private void FixedUpdate() {

        FollowPlayer();

    }

    private void FollowPlayer() {

        Vector3 desiredPosition = new Vector3(_player.position.x/_sensitivity, _player.position.y, _player.position.z/_sensitivity) + _locOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.125f);
        transform.position = smoothedPosition;

    }

}
