using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _cube;
    private GameObject _generated;
    private MeshRenderer _meshRenderer;
    [SerializeField] private float _destroyDistantion;

    private void Update() {

        if(_generated == null || Vector3.Distance(transform.position, _generated.transform.position) > _destroyDistantion) SpawnCube();

    }

    public void SpawnCube() {

        Destroy(_generated);
        _generated = Instantiate(_cube, transform.position, transform.rotation, transform);
        _meshRenderer = _generated.GetComponent<MeshRenderer>();
        _meshRenderer.material.color = new Color(_meshRenderer.material.color.r, _meshRenderer.material.color.g, _meshRenderer.material.color.b, 0);
        StartCoroutine(FadeOut());

    }

    IEnumerator FadeOut() {

        Color color = _meshRenderer.material.color;

        for(float alpha = 0f; alpha <= 1f; alpha += 0.02f) {
            color.a = alpha;
            _meshRenderer.material.color = color;
            yield return null;
        }

    }

}
