using UnityEngine;

public class FallingDown : MonoBehaviour
{

    public Interactions interactions;

    private void Update() {

        if(transform.position.y <= -30f) {
            transform.position = Vector3.zero; //Change to checkpoint, if player
            interactions.GetDamage(1);
        }

    }

}
