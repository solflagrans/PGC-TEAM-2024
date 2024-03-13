using System.Collections;
using UnityEngine;

public class Tumbler : MonoBehaviour
{

    private bool _activated;

    private float _angle;
    private float _shear;
    
    private AudioSource _audioSource;

    public bool Activated { get => _activated; set => _activated = value; }

    private void Start() {
        
        _audioSource = GetComponent<AudioSource>();

        AudioHandler.Instance.puzzleSources.Add(_audioSource);

    }

    private void Turn() {

        _activated = !_activated;

        _angle = 0;
        _shear = 0;

        if(_activated) StartCoroutine(Activate());
        else StartCoroutine(Deactivate());

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

    IEnumerator Activate() {

        for(int loop = 0; loop < 32;  loop++) {
            _angle += 1.875f;
            _shear += 0.002f;
            transform.localRotation = Quaternion.Euler(_angle, 0, 0);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 1.509f + _shear);
            yield return null;
        }

    }

    IEnumerator Deactivate() {

        for(int loop = 0; loop < 32; loop++) {
            _angle -= 1.875f;
            _shear -= 0.002f;
            transform.localRotation = Quaternion.Euler(60 + _angle, 0, 0);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 1.573f + _shear);
            yield return null;
        }

    }

}
