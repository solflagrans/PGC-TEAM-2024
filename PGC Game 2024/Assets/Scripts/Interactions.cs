using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
      public int trapDamage;

      private void OnCollisionEnter(Collision coll){
          if (coll.collider.CompareTag("Trap"))
          {
             GetDamage(trapDamage);
          }
      }
       private void OnTriggerEnter(Collider coll)
        {
           if(coll.CompareTag("Collectible"))
           {
             SaveCollectible(coll.gameObject);
           }
        }
     
        private void SaveCollectible(GameObject collectible)
        {
           PlayerPrefs.SetInt(collectible.name, 1);
           Destroy(collectible);
        }
        
        private void GetDamage(int damage)
        {
           if (!gameObject.GetComponent<MC_InGameInformation>().isInvulnerable)
           {
              gameObject.GetComponent<MC_InGameInformation>().hp -= damage;
              gameObject.GetComponent<MC_InGameInformation>().isInvulnerable = true;
              Invoke("RemoveInvulnerable", 3f);
           }
        }

        private void RemoveInvulnerable()
        {
          gameObject.GetComponent<MC_InGameInformation>().isInvulnerable = false;
        }
}
