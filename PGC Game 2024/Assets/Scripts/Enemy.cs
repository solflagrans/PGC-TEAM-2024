using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     public Vector3 [] movePoints;
     private bool isMovingForward = true;
     public float enemySpeed;
     private int keyPointNum = 0;
     public float waitingTime;

     private bool canGo = true;

     private int time = 0;
     void Update()
    {
        EnemyMoving();
    }
    void EnemyMoving()
    {
    if(canGo){
        if (isMovingForward )
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoints[keyPointNum],
                Time.deltaTime * enemySpeed);
            if (Vector3.Distance(transform.position, movePoints[keyPointNum]) < 0.001f)
            {
                keyPointNum++;
                canGo = false;
                StartCoroutine(Wait(waitingTime));
                if (keyPointNum == movePoints.Length)
                {
                    keyPointNum -= 2;
                    isMovingForward = false;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoints[keyPointNum],
                Time.deltaTime * enemySpeed);
            if (Vector3.Distance(transform.position, movePoints[keyPointNum]) < 0.001f)
            {
                keyPointNum--;
                canGo = false;
                StartCoroutine(Wait(waitingTime));
                if (keyPointNum == 0)
                { 
                    isMovingForward = true;
                }
            }
        }
        }
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canGo = true;
    }
}
