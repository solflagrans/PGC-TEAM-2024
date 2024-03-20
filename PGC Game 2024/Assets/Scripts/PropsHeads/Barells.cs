using UnityEngine;

public class Barells : MonoBehaviour
{

    public GameObject honey;
    private DestructionObjects destruction;

    private void Start() {
        
        destruction = GetComponent<DestructionObjects>();

    }

    private void GiveHoney() {

        for(int i = 0; i < Random.Range(2, 4); i++) Instantiate(honey, transform.position + Vector3.up * 2f, transform.rotation);

    }

    private void OnCollisionEnter(Collision col) {

        if(col.collider.CompareTag("Sword")) {
            GiveHoney();
            destruction.Replace();
        }

    }

}
