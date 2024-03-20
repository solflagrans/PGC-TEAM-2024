using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private SaveHandler _saveHandler;

    private void Start() {

        _saveHandler = SaveHandler.Instance;

        if(GameInformation.Instance.LastCheckpoint == this) _saveHandler.CheckpointLoad();

    }

    private void Update() {

        if(GameInformation.Instance.LastCheckpoint != this) return;

        if(MovingController.Instance.transform.position.y < transform.position.y - 5f) {
            MovingController.Instance.transform.position = transform.position;
            GiveDamage();
        }

    }

    private void OnTriggerEnter(Collider col) {

        if(GameInformation.Instance.LastCheckpoint == this) return;

        if(col.gameObject.CompareTag("Player")) {
            _saveHandler.CheckpointSave();
            GameInformation.Instance.LastCheckpoint = this;
            PlayerInformation.Instance.Hp = PlayerInformation.Instance.MaxHp;
        }

    }

    private void GiveDamage() {

        PlayerInformation.Instance.Hp -= 1;

    }

    private void OnDestroy() {

        GameInformation.Instance.LastCheckpoint = null;

    }

}
