using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackSpawn : MonoBehaviour
{
    public Transform[] spawners;
    public float waitTime;
    int n;
    private GameObject spnd;
    [SerializeField] private GameObject smallAtk;
    [SerializeField] private GameObject hugeAtk;
    public bool canAttack = true;
    private void Start()
    {
        StartCoroutine(SpawnAttack());
    }

    IEnumerator SpawnAttack()
    {
        while (canAttack)
        {
            yield return new WaitForSecondsRealtime(waitTime);
            n = Random.Range(0, spawners.Length);
            if (n % 2 == 0)
            {
                Attack(spawners[n], smallAtk);
            }
            else
            {
                Attack(spawners[n], hugeAtk);
            }
        }
    }
    void Attack(Transform s, GameObject atk)
    {
        spnd = Instantiate(atk);
        spnd.transform.position = s.transform.position;
        spnd.GetComponent<Rigidbody>().AddForce(1, 0, 1);
    }
}
