using System.Collections;
using UnityEngine;

public class DisappearingPlatform : Platform
{
    [Header("Preferences [DisappearingPlatform]")]
    [SerializeField] private float disappearTime;
    [SerializeField] private float appearTime;


    public override void OnCollisionEnter(Collision col) {

        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(Disappear());
        }

        base.OnCollisionEnter(col);

    }

    IEnumerator Disappear() {

        yield return new WaitForSeconds(disappearTime);

        Color c = _MeshRenderer.material.color;

        Hide = false;

        for(float alpha = 1f; alpha >= 0; alpha -= 0.005f) {
            c.a = alpha;
            _MeshRenderer.material.color = c;
            yield return null;
        }

        gameObject.GetComponent<BoxCollider>().enabled = false;

        StartCoroutine(Appear());

    }

    IEnumerator Appear() {

        yield return new WaitForSeconds(appearTime);

        Hide = true;

        gameObject.GetComponent<BoxCollider>().enabled = true;

    }
}
