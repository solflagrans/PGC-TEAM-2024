using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
      public int trapDamage;
      public int enemyDamage;
      public AudioClip collectHoneySound;
      public AudioClip damageSound;
      public GameObject dialogueWindow;
      public List<string> testDialogue;
      public GameObject shopWindow;
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

         /*if(coll.CompareTag("CheckPoint"))
           {
              gameObject.GetComponent<PlayerInformation>().SaveGame();
           } */
           
        }

       private void OnTriggerStay(Collider coll)
       {
          if (coll.gameObject.name == "Engineer")
          {
             if (Input.GetKey(KeyCode.E))
             {
                OpenShop();
             }
          }
       }

       private void OpenShop()
       {
          Cursor.visible = shopWindow.activeSelf;
          shopWindow.SetActive(!shopWindow.activeSelf);
       }
        public void SaveCollectible(GameObject collectible)
        {
           if (!PlayerPrefs.HasKey(collectible.name))
           {
              //gameObject.GetComponent<MC_InGameInformation>().collectibles.Add(collectible.name);
              PlayerPrefs.SetInt(collectible.name, 1);
           }

           Destroy(collectible);
        }

        public void GetDamage(int damage)
        {
           if (!gameObject.GetComponent<PlayerInformation>().IsInvulnerable)
           {
              gameObject.GetComponent<Interactions>().PlaySound(damageSound);
              gameObject.GetComponent<PlayerInformation>().Hp -= damage;
              gameObject.GetComponent<PlayerInformation>().IsInvulnerable = true;
              Invoke("RemoveInvulnerable", 3f);
           }
        }
        
        private void RemoveInvulnerable()
        {
          gameObject.GetComponent<PlayerInformation>().IsInvulnerable = false;
        }

        public void CollectHoney(GameObject honey)
        {
           if (gameObject.GetComponent<PlayerInformation>().CollectedHoney <
               gameObject.GetComponent<PlayerInformation>().MaxHoneyAmount)
           {
              gameObject.GetComponent<PlayerInformation>().CollectedHoney++;
              gameObject.GetComponent<Interactions>().PlaySound(collectHoneySound);
              Destroy(honey);
           }
           else
           {
              Debug.Log("мешочек заполнен!");
           }
        }

        public void ChangeSwordAura(int auraNum)
        {
           gameObject.GetComponent<PlayerInformation>().SwordAura = auraNum;
        }
        public void StartDialogue(List<string> dialogue)
        {
           gameObject.GetComponent<MovingController>().enabled = false;
           gameObject.GetComponent<DialogUI_Controller>().phrases.Clear();
           for(int i = 0; i < dialogue.Count;i++){           
              gameObject.GetComponent<DialogUI_Controller>().phrases.Add(dialogue[i]);
           }
           gameObject.GetComponent<DialogUI_Controller>().StartWriting();
           dialogueWindow.SetActive(true);
        }
        public void EndDialogue()
        {
           gameObject.GetComponent<MovingController>().enabled = true;
           dialogueWindow.SetActive(false);
        }

        public void PlaySound(AudioClip sound)
        {
           AudioSource au = gameObject.GetComponent<AudioSource>();
           if (au.clip != sound)
           {
              au.clip = sound;
           }
           au.Play();
        }
}
