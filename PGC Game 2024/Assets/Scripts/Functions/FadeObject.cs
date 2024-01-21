using System.Collections;
using UnityEngine;

public class FadeObject : MonoBehaviour
{

    private float _time;

    [Header("Preferences")]
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private float _timer;
    [SerializeField] private bool _selfDestruction;

    private void Update() {

        if(_time < _timer) _time += Time.deltaTime;
        else Fade(_mesh);

    }

    private IEnumerator _fade() {

        Color c = _mesh.material.color;
        for(float alpha = 1f; alpha >= 0; alpha -= 0.005f) {
            c.a = alpha;
            _mesh.material.color = c;
            yield return null;
        }

        if(_selfDestruction) Destroy(gameObject);

    }

    public void Fade(MeshRenderer mesh) {

        _mesh = mesh;
        StartCoroutine(_fade());

    }
}
