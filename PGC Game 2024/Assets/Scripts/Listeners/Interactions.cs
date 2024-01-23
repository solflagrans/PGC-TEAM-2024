using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
      public GameObject dialogueWindow;
      public List<string> testDialogue;
      public GameObject shopWindow;

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
