using UnityEngine;

public class DestructionObjects : MonoBehaviour
{

    [Header("Preferences")]
    [SerializeField] private GameObject _destructedObject;
    [SerializeField] private float _explosionStrength = 2f;

    public void Replace() {

        GameObject replaced = Instantiate(_destructedObject, transform.position, transform.rotation);

        replaced.GetComponentInChildren<Rigidbody>().AddForce(transform.forward * _explosionStrength, ForceMode.Impulse);

        Destroy(gameObject);

    }
}
