using UnityEngine;

public abstract class Collectible : MonoBehaviour
{

    protected int id;

    public virtual void Start() {

        if(GameInformation.Instance.Collectibles.Contains(id)) Destroy(gameObject);

    }

    public virtual void PickUp() {

        GameInformation.Instance.Collectibles.Add(id);
        SaveHandler.Instance.CollectSave();

        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider col) {

        if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Robot")) PickUp();

    }

}
