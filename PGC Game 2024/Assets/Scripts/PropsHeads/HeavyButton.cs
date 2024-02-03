using UnityEngine;

public class HeavyButton : MonoBehaviour
{

    private MeshRenderer _meshRenderer;
    private bool _activated;

    public bool Activated { get => _activated; }

    private void Start() {
        
        _meshRenderer = GetComponent<MeshRenderer>();

    }

    private void Activate() {

        _activated = true;
        _meshRenderer.material.color = Color.green;

    }

    private void Deactivate() {

        _activated = false;
        _meshRenderer.material.color = Color.red;

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
