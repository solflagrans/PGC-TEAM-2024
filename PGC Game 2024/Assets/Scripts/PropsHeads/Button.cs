using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{

    private MeshRenderer _meshRenderer;
    private bool _inTrigger;
    private bool _activated = false;
    private AudioSource _audioSource;

    [SerializeField] private GameObject _help;

    public bool Activated { get => _activated; set => _activated = value; }

    private void Start() {
        
        _meshRenderer = GetComponent<MeshRenderer>();
        _audioSource = GetComponent<AudioSource>();

        AudioHandler.Instance.puzzleSources.Add(_audioSource);

    }

    private void Update() {

        if(Input.GetKeyUp(KeyCode.E) && _inTrigger) {
            Activate();
        }

    }

    private void Activate() {

        _activated = !_activated;

        _audioSource.PlayOneShot(AudioHandler.Instance.buttonPress);

        StartCoroutine(ColorChanger(_meshRenderer, Color.white, Color.green));

    }

    IEnumerator ColorChanger(MeshRenderer meshRenderer, Color oldColor, Color newColor) {

        meshRenderer.material.color = newColor;

        yield return new WaitForSeconds(1f);

        meshRenderer.material.color = oldColor;

    }

    private void OnTriggerEnter(Collider col) {
        
        if(col.CompareTag("Player")) {
            _inTrigger = true;
            _help.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider col) {
        
        if(col.CompareTag("Player")) {
            _inTrigger = false;
            _help.SetActive(false);
        }

    }

}
