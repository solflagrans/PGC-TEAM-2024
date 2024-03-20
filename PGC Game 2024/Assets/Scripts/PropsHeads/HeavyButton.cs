using UnityEngine;

public class HeavyButton : MonoBehaviour
{

    private MeshRenderer _meshRenderer;
    private bool _activated;
    private AudioSource _audioSource;

    private bool _cubeOn;
    private bool _playerOn;
    private bool _robotOn;

    public bool Activated { get => _activated; }

    private void Start() {
        
        _meshRenderer = GetComponent<MeshRenderer>();
        _audioSource = GetComponent<AudioSource>();

        AudioHandler.Instance.puzzleSources.Add(_audioSource);

    }

    private void Activate() {

        if(_activated) return;

        _activated = true;
        _meshRenderer.material.color = Color.green;

        _audioSource.PlayOneShot(AudioHandler.Instance.heavyButtonOn);

    }

    private void Deactivate() {

        if(_cubeOn || _playerOn || _robotOn) return;

        _activated = false;
        _meshRenderer.material.color = Color.white;

        _audioSource.PlayOneShot(AudioHandler.Instance.heavyButtonOff);

    }

    private void OnTriggerEnter(Collider col) {
        
        if(col.gameObject.CompareTag("Cube")) {
            _cubeOn = true;
            Activate();
        }
        if(col.gameObject.CompareTag("Player")) {
            _playerOn = true;
            Activate();
        }
        if(col.gameObject.CompareTag("Robot")) {
            _robotOn = true;
            Activate();
        }

    }

    private void OnTriggerExit(Collider col) {

        if(col.gameObject.CompareTag("Cube")) {
            _cubeOn = false;
            Deactivate();
        }
        if(col.gameObject.CompareTag("Player")) {
            _playerOn = false;
            Deactivate();
        }
        if(col.gameObject.CompareTag("Robot")) {
            _robotOn = false;
            Deactivate();
        }

    }

}
