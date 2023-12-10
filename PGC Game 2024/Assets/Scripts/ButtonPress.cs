using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{

    private bool inCol;

    public bool pressed;

    private void Update() {

        if(Input.GetKeyDown(KeyCode.E)) {
            pressed = true;
        }

    }

    private void OnTriggerEnter(Collider col) {
        
        if(col.CompareTag("Player")) {
            inCol = true;
        }

    }

    private void OnTriggerExit(Collider col) {
        
        if(col.CompareTag("Player")) {
            inCol = false;
        }

    }

}
