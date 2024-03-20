using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    private int _step;

    [SerializeField] private Transform _tutorial;
    private List<GameObject> _texts = new List<GameObject>();
    [SerializeField] private GameObject[] _platforms;

    private bool _wPressed;
    private bool _aPressed;
    private bool _sPressed;
    private bool _dPressed;

    private bool _jumpPressed;

    private bool _doubleJumped;

    private bool _robotUsed;

    [SerializeField] private CheckCollider[] _triggers;

    private void Start() {
        
        for(int i = 0; i < _tutorial.childCount; i++) {
            _texts.Add(_tutorial.GetChild(i).gameObject);
        }

        foreach(GameObject platform in _platforms) {
            platform.SetActive(false);
        }

    }

    private void Update() {
        
        PerformStep();

    }

    private void PerformStep() {

        switch(_step) {
            case 0:
                if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) _wPressed = true;
                if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) _aPressed = true;
                if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) _sPressed = true;
                if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) _dPressed = true;
                if(_wPressed && _aPressed && _sPressed && _dPressed) {
                    _texts[0].SetActive(false);
                    _step = 1;
                } else _texts[0].SetActive(true);
                break;
            case 1:
                if(Input.GetKeyDown(KeyCode.Space)) _jumpPressed = true;
                if(_jumpPressed) {
                    _texts[1].SetActive(false);
                    _step = 2;
                } else _texts[1].SetActive(true);
                break;
            case 2:
                if(!MovingController.Instance.CanJump && !MovingController.Instance.CanDoubleJump) _doubleJumped = true;
                if(_doubleJumped) {
                    _texts[2].SetActive(false);
                    _step = 3;
                } else _texts[2].SetActive(true);
                break;
            case 3:
                _platforms[0].SetActive(true);
                if(_triggers[0].PlayerIn) {
                    _texts[3].SetActive(false);
                    _step = 4;
                } else _texts[3].SetActive(true);
                break;
            case 4:
                _platforms[1].SetActive(true);
                _platforms[2].SetActive(true);
                _platforms[3].SetActive(true);
                if(_triggers[1].PlayerIn) {
                    _texts[4].SetActive(false);
                    _step = 5;
                } else _texts[4].SetActive(true); 
                break;
            case 5:
                if(_triggers[2].PlayerIn) {
                _texts[5].SetActive(false);
                _step = 6;
                } else _texts[5].SetActive(true); 
                break;
            case 6:
                if(Input.GetKeyDown(KeyCode.R)) _robotUsed = true;
                if(_robotUsed) {
                _texts[6].SetActive(false);
                _step = 7;
                } else _texts[6].SetActive(true); 
                break;
            case 7:
                if(_triggers[3].PlayerIn) {
                    _texts[7].SetActive(false);
                    _step = 8;
                } else _texts[7].SetActive(true); 
                break;
            case 8:
                if(_triggers[4].PlayerIn) {
                    _texts[8].SetActive(false);
                    _step = 9;
                } else _texts[8].SetActive(true); 
                break;
            case 9:
                if(_triggers[5].PlayerIn) {
                    _texts[9].SetActive(false);
                    _step = 10;
                } else _texts[9].SetActive(true);
                break;
            case 10:
                    gameObject.SetActive(false);
                break;
        }

    }

}
