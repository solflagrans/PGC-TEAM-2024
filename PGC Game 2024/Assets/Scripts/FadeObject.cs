using System.Collections;
using UnityEngine;

public class FadeObject : MonoBehaviour
{

    private MeshRenderer mesh;
    private float time;
    public float timer;
    public bool willDestroy;

    private void Start() {

        mesh = GetComponent<MeshRenderer>();

    }

    public void Update() {

        if(time < timer) {
            time += Time.deltaTime;
        } else {
            StartCoroutine(Fade());
        }

    }

    IEnumerator Fade() {
        Color c = mesh.material.color;
        for(float alpha = 1f; alpha >= 0; alpha -= 0.005f) {
            c.a = alpha;
            mesh.material.color = c;
            yield return null;
        }

        if(willDestroy) Destroy(gameObject);
    }
}
