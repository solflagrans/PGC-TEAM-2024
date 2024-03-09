using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : Platform
{
   [Header("Preferences [DisappearingPlatform]")]
   [SerializeField] private float disappearTime;
   private void OnCollisionEnter(Collision coll)
   {
      if (coll.collider.CompareTag("Player"))
      {
         StartCoroutine(Disappear());
      }
   }

   IEnumerator Disappear()
   {
      for (int i = 1; i < 11; i++)
      {
         
         yield return new WaitForSecondsRealtime(disappearTime);
         print("aaa");
         _MeshRenderer.material.color = new Color(_MeshRenderer.material.color.r, _MeshRenderer.material.color.g, _MeshRenderer.material.color.b, 1 - 0.1f*i);
         
      }
      _MeshRenderer.material.color = new Color(_MeshRenderer.material.color.r, _MeshRenderer.material.color.g, _MeshRenderer.material.color.b, 0);
      gameObject.GetComponent<BoxCollider>().enabled = false;
   }
}
