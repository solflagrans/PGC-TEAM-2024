using System.Collections;
using System.Collections.Generic;
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
            transform.position -= Vector3.MoveTowards(transform.position,new Vector3(clueLocations[puzzleNum].position.x,transform.position.y, clueLocations[puzzleNum].position.z), 0.5f)*speed*Time.deltaTime;
        }
        if(Vector3.Distance(transform.position, clueLocations[puzzleNum].position) < 0.2f){
            isMoving = false;
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
