using System.Collections;
using UnityEngine;

public class Gate : MonoBehaviour
{

    [SerializeField] private bool _flip;
    [SerializeField] private bool _reverse;
    [SerializeField] private int isometicAngle;

    private bool _opened;
    private bool _inUse;

    public void TurnOn() {

        if(!_opened && !_inUse) {
            StartCoroutine(Open());
        }

    }

    public void TurnOff() {

        if(_opened && !_inUse) {
            StartCoroutine(Close());
        }

    }

    IEnumerator Open() {

        _opened = true;
        _inUse = true;

        if(_opened) {
            for(float angle = 0; angle < 90f; angle += 0.5f) {
                if(!_reverse && !_flip) transform.rotation = Quaternion.Euler(0, angle + isometicAngle, 0);
                if(_reverse && !_flip) transform.rotation = Quaternion.Euler(0, -angle + isometicAngle, 0);
                if(!_reverse && _flip) transform.rotation = Quaternion.Euler(90 + angle, -90 + isometicAngle, -90);
                if(_reverse && _flip) transform.rotation = Quaternion.Euler(-90 - angle, -90 + isometicAngle, -90);
                yield return null;
            }
        }

        _inUse = false;

    }

    IEnumerator Close() {

        _opened = false;
        _inUse = true;

            for(float angle = 0; angle > -90f; angle -= 0.5f) {
                if(!_reverse && !_flip) transform.rotation = Quaternion.Euler(0, 90 + angle + isometicAngle, 0);
            if(_reverse && !_flip) transform.rotation = Quaternion.Euler(0, -90 - angle + isometicAngle, 0);
            if(!_reverse && _flip) transform.rotation = Quaternion.Euler(180 + angle, -90 + isometicAngle, -90);
            if(_reverse && _flip) transform.rotation = Quaternion.Euler(-180 - angle, -90 + isometicAngle, -90);
            yield return null;
            }

        _inUse = false;

    }

}
