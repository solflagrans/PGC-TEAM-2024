using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{

    private MeshRenderer _meshRenderer;
    private bool _inTrigger;
    private bool _activated = false;

    public bool Activated { get => _activated; set => _activated = value; }

    private void Start() {
        
        _meshRenderer = GetComponent<MeshRenderer>();

    }

    private void Update() {

        if(Input.GetKeyUp(KeyCode.E) && _inTrigger) {
            Activate();
        }

    }

    private void Activate() {

        _activated = !_activated;
        StartCoroutine(ColorChanger(_meshRenderer, Color.red, Color.green));

    }

    IEnumerator ColorChanger(MeshRenderer meshRenderer, Color oldColor, Color newColor) {

        meshRenderer.material.color = newColor;

        yield return new WaitForSeconds(1f);

        meshRenderer.material.color = oldColor;

    }

    private void OnTriggerEnter(Collider col) {
        
        if(col.CompareTag("Player")) {
            _inTrigger = true;
        }

    }

    private void OnTriggerExit(Collider col) {
        
        if(col.CompareTag("Player")) {
            _inTrigger = false;
        }

    }

}
