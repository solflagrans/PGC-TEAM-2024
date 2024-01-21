using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    public GameObject winText;

    private void OnTriggerEnter(Collider col) {
        if(col.CompareTag("Player")) {
            winText.SetActive(true);
        }
    }

}
