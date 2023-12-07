using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
      public int trapDamage;
      public int enemyDamage;
      private void OnCollisionEnter(Collision coll){
          if (coll.collider.CompareTag("Trap"))
          {
             GetDamage(trapDamage);
          }

          if (coll.collider.CompareTag("Enemy"))
          {
             GetDamage(enemyDamage);
          }
      }
       private void OnTriggerEnter(Collider coll)
        {
           if(coll.CompareTag("Collectible"))
           {
             SaveCollectible(coll.gameObject);
           }

           if (coll.CompareTag("Honey"))
           {
              CollectHoney(coll.gameObject);
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

        void CollectHoney(GameObject honey)
        {
           if (gameObject.GetComponent<MC_InGameInformation>().collectedHoney <
               gameObject.GetComponent<MC_InGameInformation>().maxHoneyAmount)
           {
              gameObject.GetComponent<MC_InGameInformation>().collectedHoney++;
              Destroy(honey);
           }
           else
           {
              Debug.Log("мешочек заполнен!");
           }
        }

        public void ChangeSwordAura(int auraNum)
        {
           gameObject.GetComponent<MC_InGameInformation>().swordAura = auraNum;
        }
}
