using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tumbler : MonoBehaviour
{

    private bool _activated;
    
    private AudioSource _audioSource;

    public bool Activated { get => _activated; set => _activated = value; }

    private void Start() {
        
        _audioSource = GetComponent<AudioSource>();

        AudioHandler.Instance.puzzleSources.Add(_audioSource);

    }

    private void Turn() {

        _activated = !_activated;

        if(_activated) {
            transform.Rotate(60f, 0, 0);
            transform.localPosition += new Vector3(0, 0, 0.064f);
        } else {
            transform.Rotate(-60f, 0, 0);
            transform.localPosition -= new Vector3(0, 0, 0.064f);
        }

        _audioSource.PlayOneShot(AudioHandler.Instance.buttonPress);

    }

    private void OnTriggerEnter(Collider col) {

        if(col.gameObject.CompareTag("Robot")) {
            Turn();
        }
        if(col.gameObject.CompareTag("Player")) {
            Turn();
        }

    }

    /*IEnumerator Activate() {

        Vector3 currentPosition = transform.localPosition;

        for(float shear = 0f; shear < 0.064f; shear += 0.002f) {
            transform.localPosition = currentPosition + new Vector3(0, 0, shear);
            yield return null;
        }

        for(float angle = 0f; angle < 60f; angle += 1.875f) {
            transform.localRotation = Quaternion.Euler(angle, 0, 0);
            yield return null;
        }

    } try to write smooth alghoritm later. it's weirdy*/ 

}
