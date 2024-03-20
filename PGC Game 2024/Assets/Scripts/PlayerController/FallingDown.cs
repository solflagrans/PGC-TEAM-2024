using UnityEngine;

public class FallingDown : MonoBehaviour
{

    private void Update() {

        if(GameInformation.Instance.LastCheckpoint != null) return;

        if(transform.position.y <= -30f) {
            transform.position = Vector3.zero; //Change to checkpoint, if player
            GiveDamage();
        }

    }

    private void GiveDamage() {

        PlayerInformation.Instance.Hp -= 1;

    }

}
