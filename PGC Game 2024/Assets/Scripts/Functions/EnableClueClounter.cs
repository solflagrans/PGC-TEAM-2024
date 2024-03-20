using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableClueClounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            StartCoroutine(GiveClue.Instance.Clue());
        }
    }
}
