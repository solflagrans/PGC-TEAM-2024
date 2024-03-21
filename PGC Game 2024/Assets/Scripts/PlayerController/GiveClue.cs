using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GiveClue : MonoBehaviour
{
    public static GiveClue Instance;
    public Transform [] clueLocations;
    private int puzzleNum = 0;
    [SerializeField] private float clueTime;
    private bool isMoving = false;
    public float speed;
    public GameObject mc;
    private void Awake()
    {

        if (!Instance) Instance = this;

    }
    private void Update()
    {
        print(puzzleNum);
        if (isMoving)
        {
            transform.position += transform.forward*speed*Time.deltaTime;
        }
       if(Vector3.Distance(transform.position, clueLocations[puzzleNum].position) < 0.5f){
            isMoving = false;
        }
      if (Vector3.Distance(transform.position, mc.transform.position) >= 2.5f)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player") && !isMoving)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            GetComponent<CharacterController>().enabled = true;
            GetComponent<RoBot>().canFollow = true;
            if (puzzleNum < clueLocations.Length-1)
            {
                puzzleNum ++;
            }     
        }
    }
    public IEnumerator Clue(GameObject clueObj)
    {

        yield return new WaitForSeconds(clueTime);
        print(puzzleNum);
        GetComponent<RoBot>().canFollow = false;
        transform.LookAt(clueLocations[puzzleNum].position);
        isMoving = true;
        GetComponent<CharacterController>().enabled = false;
        clueObj.SetActive(false);
    }

}
