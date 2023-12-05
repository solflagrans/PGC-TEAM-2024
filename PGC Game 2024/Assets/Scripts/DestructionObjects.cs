using UnityEngine;

public class DestructionObjects : MonoBehaviour
{

    public GameObject destructibleObject;

    public bool doDestruct;

    void Update() {
        if(doDestruct) {
            Replace();
        }
    }

    private void Replace() {

        GameObject replaced = Instantiate(destructibleObject, transform.position, transform.rotation);

        replaced.GetComponentInChildren<Rigidbody>().AddForce(transform.forward * 2f, ForceMode.Impulse);

        Destroy(gameObject);

    }
}
