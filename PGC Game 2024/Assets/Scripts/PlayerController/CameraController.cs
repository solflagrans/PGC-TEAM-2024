using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Preferences")]
    public Vector3 locOffset;

    [Header("Instances")]
    public Transform player;

    void FixedUpdate() {

        FollowPlayer();

    }
    void FollowPlayer() {

        Vector3 desiredPosition = player.position + locOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.125f);
        transform.position = smoothedPosition;

        transform.LookAt(new Vector3(player.position.x, player.position.y + 1f, player.position.z));

    }
}
