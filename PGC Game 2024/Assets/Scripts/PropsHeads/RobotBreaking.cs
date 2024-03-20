using UnityEngine;

public class RobotBreaking : MonoBehaviour
{

    [SerializeField] private GameObject[] _bodyParts;
    [SerializeField] private GameObject _smoke;
    private int _damaged;
    [SerializeField] private Transform _world;
    [SerializeField] private Interactions _interactions;

    private void Update() {
        


    }

    private void GiveDamage() {

        switch (_damaged) {
            case 0:
                _bodyParts[0].transform.SetParent(_world);
                break;
            case 1:
                _bodyParts[1].transform.SetParent(_world);
                break;
            case 2:
                _bodyParts[2].transform.SetParent(_world);
                _interactions.enabled = true;
                break;
        }

    }

    private void OnTriggerEnter(Collider col) {
        
        if(col.gameObject.CompareTag("Cube")) {
            GiveDamage();
            _damaged += 1;
            col.gameObject.SetActive(false);
        }

    }

}
