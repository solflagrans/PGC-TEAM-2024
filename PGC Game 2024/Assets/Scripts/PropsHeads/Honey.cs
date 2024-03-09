using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class Honey : MonoBehaviour
{

    private int _cost;
    private AudioSource _honeySound;

    private void Awake() {

        _honeySound ??= GetComponent<AudioSource>();

    }

    private void Start() {

        _cost = Random.Range(1, 3);

        MeshRenderer _mesh = GetComponent<MeshRenderer>();
        Color _color = new Color(1f, 1f - _cost / 10, 1f);
        _mesh.material.color = _color;

    }

    private void OnTriggerEnter(Collider col) {

        if(col.gameObject.CompareTag("Player")) {

            if(PlayerInformation.Instance.CollectedHoney == PlayerInformation.Instance.MaxHoneyAmount) return;

            PlayerInformation.Instance.CollectedHoney++;
            if(_honeySound.clip != null) _honeySound.Play();

            Destroy(gameObject);

        }

    }

}
