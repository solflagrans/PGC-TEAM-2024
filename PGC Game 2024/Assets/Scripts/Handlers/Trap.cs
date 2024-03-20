using UnityEngine;

public class Trap : MonoBehaviour
{

    public void GiveDamage() {

        PlayerInformation.Instance.Hp -= 1;

    }

    private void OnCollisionEnter(Collision col) {

        if(col.gameObject.CompareTag("Player")) GiveDamage();

    }

}
