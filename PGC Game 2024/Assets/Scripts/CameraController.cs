using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Preferences")]
    public Vector3 locOffset;

    [Header("Instances")]
    public Transform player;

    void Update() {

        FollowPlayer();
    }
    void FollowPlayer() {

        Vector3 desiredPosition = player.position + new Vector3(player.rotation.x * locOffset.x, locOffset.y, locOffset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.125f);
        transform.position = smoothedPosition;

        //Дописать, чтобы камера могла слегка вращаться по горизонтали и вертикали. Через Lerp

    }
}
