using UnityEngine;

public abstract class Trap : MonoBehaviour
{

    public void Initialize() {

    }

    public virtual void GiveDamage() {

        PlayerInformation.Instance.Hp -= 1;

    }

    public abstract void Active();

    private void OnCollisionEnter(Collision col) {

        if(col.gameObject.CompareTag("Player")) GiveDamage();

    }

}
