using System.Collections;
using UnityEngine;

public class Elevator : Platform
{

    [Header("Preferences [Elevator]")]
    [SerializeField] private float _height;
    [SerializeField] private float _speed;
    [SerializeField] private float _waitTime;

    [Header("Technical")]
    private float _startHeight;
    private string _direction = "Up";
    private bool _waiting;
    private bool _enabled = true;

    public bool Enabled { get => _enabled; set => _enabled = value; }

    public override void Start() {

        _startHeight = transform.position.y;

        base.Start();

    }

    public override void Update() {

        if(Enabled) Lift();

        base.Update();

    }

    private void Lift() {

        if(_waiting) return;

        if(Mathf.Approximately(transform.position.y, _startHeight)) {
            StartCoroutine(Wait(_waitTime));
            _direction = "Up";
        } else if(Mathf.Approximately(transform.position.y, _startHeight + _height)) {
            StartCoroutine(Wait(_waitTime));
            _direction = "Down";
        }

        Move();

    }

    private void Move() {

        if(_direction == "Up") transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, _startHeight + _height, transform.position.z), _speed * Time.deltaTime);
        if(_direction == "Down") transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, _startHeight, transform.position.z), _speed * Time.deltaTime);
    }


    IEnumerator Wait(float waitTime) {

        _waiting = true;

        yield return new WaitForSeconds(waitTime);

        _waiting = false;

    } 

}
