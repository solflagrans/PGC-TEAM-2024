using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWinChip : MonoBehaviour
{ 
    public float speed;
    void OnCollisionEnter(Collision coll)
    {
        PRINT("1");
        if (coll.collider.CompareTag("WinChip"))
        {
            PRINT("2");
            gameObject.GetComponent<Animator>().SetTrigger("Jump");
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up *speed, ForceMode.Impulse);
        }
    }
}
