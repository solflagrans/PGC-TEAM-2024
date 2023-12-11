using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{

    [HideInInspector] public bool playerIn;
    public GameObject helpText;

    public void OnTriggerEnter(Collider col) {
        
        if(col.CompareTag("Player") || col.CompareTag("Robot")) {
            playerIn = true;
            if(helpText != null) helpText.SetActive(true);
        }

    }

    public void OnTriggerExit(Collider col) {
     
        if(col.CompareTag("Player") || col.CompareTag("Robot")) {
            playerIn = false;
            if(helpText != null) helpText.SetActive(false);
        }

    }

}
