using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEggs : MonoBehaviour
{
    public GameObject Egg;
    public float spawnTime;
    public float deltaSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(spawnTime, Random.Range(-deltaSpawnTime, deltaSpawnTime)));
    }
    
    private IEnumerator Spawn(float time,float deltatime){
        yield return new WaitForSeconds(time+deltatime);
       GameObject egg = GameObject.Instantiate(Egg);
       egg.transform.position = gameObject.transform.position;
       StartCoroutine(Spawn(time, Random.Range(-deltatime, deltatime)));
    }

}
