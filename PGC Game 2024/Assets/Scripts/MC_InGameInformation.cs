using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_InGameInformation : MonoBehaviour
{
    public int hp;
    public bool isInvulnerable;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hp);
    }
    
}
