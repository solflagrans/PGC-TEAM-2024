using UnityEngine;

public abstract class Trap : MonoBehaviour
{

    protected int Damage;
    protected PlayerInformation PlayerInformation;

    public void Initialize(int damage, PlayerInformation playerInformation) {

        Damage = damage;
        PlayerInformation = playerInformation;

    }

    public virtual void GiveDamage() {

        PlayerInformation.Hp -= Damage;

    }

    public abstract void Active();

    private void OnCollisionEnter(Collision col) {

        if(col.gameObject.CompareTag("Player")) GiveDamage();

    }

}
