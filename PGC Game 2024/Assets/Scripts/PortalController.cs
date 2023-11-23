using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
  public string newSceneName;

  void OnTriggerEnter(Collider coll)
  {
    if (coll.name == "m_character")
    {
      SceneManager.LoadScene(newSceneName);
    }
  }

  void Update()
  {
    
  }
}
