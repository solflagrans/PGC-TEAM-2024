using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWinChip : MonoBehaviour
{
    private bool isFlying;
    public Transform tpTransform;
    public float speed;
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("WinChip"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Jump");
            isFlying = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlying)
        {
            transform.position = Vector3.MoveTowards(transform.position, tpTransform.position, speed);
        }
    }
}
