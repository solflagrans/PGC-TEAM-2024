using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioClip openSound;
    public bool isOpening = false;
    public float needRotation;
    private bool isOpened = false;
    void Update()
    {
        if (isOpening)
        {
            transform.Rotate(0,needRotation,0);
            if (transform.rotation.y / needRotation < 1)
            {
                isOpening = false;
                isOpened = true;
            }
        }
    }
    void OnTriggerEnter(Collider coll){
     if(coll.CompareTag("Player") && !isOpened){
           isOpening = true;
           print("qqq");
          //анимация механика animator.SetTrigger("ClimbIdle");
          //звук открытия gameObject.GetComponent<Interactions>().PlaySound(openSound);
     }
    }
}
