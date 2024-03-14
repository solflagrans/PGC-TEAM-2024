using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{

    private bool isOpened = false;

    [SerializeField] private GameObject _door;
    private AudioSource _sound;

    private void Start() {
        
        _sound = GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider coll) {

        if(coll.gameObject.CompareTag("Player") && !isOpened){
            StartCoroutine(OpenDoor());
            //анимация механика animator.SetTrigger("ClimbIdle");
            _sound.PlayOneShot(AudioHandler.Instance.doorOpening);
            isOpened = true;
        }

    }

    IEnumerator OpenDoor() {

        for(int angle = 0; angle < 100; angle++) {
            _door.transform.localRotation = Quaternion.Euler(_door.transform.localRotation.x, -angle, _door.transform.localRotation.z);
            yield return null;
        }

    }
}
