using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingJar : MonoBehaviour
{
    private AudioSource _jarSound;

    private void Awake()
    {

        _jarSound ??= GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            PlayerInformation.Instance.CollectedHealJars++;
            if (_jarSound.clip != null) _jarSound.Play();
            Destroy(gameObject);

        }

    }
}