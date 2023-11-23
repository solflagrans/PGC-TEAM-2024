using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_Controller : MonoBehaviour
{
   public GameObject PauseUI;

   void Update()
   {
      if (Input.GetKey(KeyCode.Escape))
      {
         Time.timeScale = 0;
         PauseUI.SetActive(!PauseUI.active);
      }
   }

   public void Continuie (){
      PauseUI.SetActive(false);
      Time.timeScale = 1;
   }

   public void Restart()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
   
   public void ToMenu (){
      SceneManager.LoadScene(0);
   }
}
