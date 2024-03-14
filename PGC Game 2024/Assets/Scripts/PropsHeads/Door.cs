using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{

    private bool isOpened = false;

    [SerializeField] private GameObject _door;

    void OnTriggerEnter(Collider coll) {

        if(coll.gameObject.CompareTag("Player") && !isOpened){
            StartCoroutine(OpenDoor());
            //анимация механика animator.SetTrigger("ClimbIdle");
            //звук открытия 
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
