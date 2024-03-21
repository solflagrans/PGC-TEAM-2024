using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float speed;
    public CubeSpawner c;
    private void OnCollisionEnter(Collision coll)
    {
        print("A");
        if (coll.collider.CompareTag("Player"))
        {
            GiveDamage();
            Destroy(gameObject);         
        }
        if (coll.collider.gameObject.name == "platform_32")
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        c.SpawnCube();
    }
    private void GiveDamage()
    {

        PlayerInformation.Instance.Hp -= 1;

    }
}
