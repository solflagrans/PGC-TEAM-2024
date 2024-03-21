using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightPlatform : MonoBehaviour
{
    public GameObject targ;
    public bool isMoving = false;
    public int speed;
    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targ.transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {

        }
    }
}
