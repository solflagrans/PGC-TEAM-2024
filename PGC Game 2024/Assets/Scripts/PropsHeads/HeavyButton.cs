using UnityEngine;

public class HeavyButton : MonoBehaviour
{

    private MeshRenderer _meshRenderer;
    private bool _activated;
    private AudioSource _audioSource;

    public bool Activated { get => _activated; }

    private void Start() {
        
        _meshRenderer = GetComponent<MeshRenderer>();
        _audioSource = GetComponent<AudioSource>();

        AudioHandler.Instance._puzzleSources.Add(_audioSource);

    }

    private void Activate() {

        _activated = true;
        _meshRenderer.material.color = Color.green;

        _audioSource.PlayOneShot(AudioHandler.Instance._heavyButtonOn);

    }

    private void Deactivate() {

        _activated = false;
        _meshRenderer.material.color = Color.red;

        _audioSource.PlayOneShot(AudioHandler.Instance._heavyButtonOff);

    }

    private void OnTriggerEnter(Collider col) {
        
        if(col.gameObject.CompareTag("Cube") || col.gameObject.CompareTag("Player")) {
            Activate();
        }

    }

    private void OnTriggerExit(Collider col) {

        if(col.gameObject.CompareTag("Cube") || col.gameObject.CompareTag("Player")) {
            Deactivate();
        }

    }

}
