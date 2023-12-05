using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{

    [HideInInspector] public bool playerIn;

    public void OnTriggerEnter(Collider col) {
        
        if(col.CompareTag("Player")) {
            playerIn = true;
        }

    }

    public void OnTriggerExit(Collider col) {
     
        if(col.CompareTag("Player")) {
            playerIn = false;
        }

    }

}