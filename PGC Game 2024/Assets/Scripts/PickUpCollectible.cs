using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollectible : MonoBehaviour
{
   private void OnTriggerEnter(Collider coll)
   {
      if(coll.CompareTag("Collectible"))
      {
        SaveCollectible(coll.gameObject);
      }
   }

   void SaveCollectible(GameObject collectible)
   {
      PlayerPrefs.SetInt(collectible.name, 1);
      Destroy(collectible.gameObject);
      
   }
}
