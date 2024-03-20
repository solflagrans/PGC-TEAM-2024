using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GiveClue : MonoBehaviour
{
    public Transform [] clueLocations;
    private int puzzleNum;
    [SerializeField] private float clueTime;
    private bool isMoving = false;
    public float speed;
    private void Start()
    {
        StartCoroutine(Clue());
    }
    private void Update()
    {
        if (isMoving)
        {
            transform.position += transform.forward*speed*Time.deltaTime;
        }
       if(Vector3.Distance(transform.position, clueLocations[puzzleNum].position) < 1f){
            isMoving = false;
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player") && !isMoving)
        {
            GetComponent<CharacterController>().enabled = true;
            GetComponent<RoBot>().canFollow = true;
            if (puzzleNum < clueLocations.Length-1)
            {
                puzzleNum ++;
            }
        }
    }
    public IEnumerator Clue()
    {

        yield return new WaitForSeconds(clueTime);
        GetComponent<RoBot>().canFollow = false;
        transform.LookAt(clueLocations[puzzleNum].position);
        isMoving = true;
        GetComponent<CharacterController>().enabled = false;
    }

}
