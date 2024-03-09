using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [Header("Preferences")]
    protected bool Static;

    protected Vector3[] Waypoints;
    protected float Speed;
    protected float TimeToWait;

    [Header("Technical")]
    private bool _wait;
    private bool _isMovingForward = true;

    private int _waypointNum;

    public void Initialize(Vector3[] waypoints, float speed, float timeToWait) {

        Waypoints = waypoints;
        Speed = speed;
        TimeToWait = timeToWait;

        Static = false;

    }

    public void Initialize() {

        Static = true;

    }

    public virtual void Update() {

        if(!Static) EnemyMoving();

    }

    public virtual void EnemyMoving() {

        if(_wait) return;

        transform.position = Vector3.MoveTowards(transform.position, Waypoints[_waypointNum], Time.deltaTime * Speed);

        if(Vector3.Distance(transform.position, Waypoints[_waypointNum]) < 0.001f) return;

        if (_isMovingForward) {
            if (_waypointNum == Waypoints.Length) _isMovingForward = false;
            else _waypointNum += 1;
        } else {
            if (_waypointNum == 0) _isMovingForward = true;
            else _waypointNum -= 1;
        }

        StartCoroutine(Wait(TimeToWait));
        _wait = true;

    }

    IEnumerator Wait(float waitTime) {

        yield return new WaitForSeconds(waitTime);

        _wait = false;

    }

    public virtual void GiveDamage() {

        PlayerInformation.Instance.Hp -= 1;

    }

}
