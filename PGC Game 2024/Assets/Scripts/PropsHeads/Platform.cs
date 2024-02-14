using UnityEngine;

public class Platform : MonoBehaviour
{

    protected MeshRenderer _MeshRenderer;

    [Header("Preferences [Platform]")]
    [SerializeField] protected bool Hide = true;

    public virtual void Start() {
        
        _MeshRenderer = GetComponent<MeshRenderer>();

        if(Hide) _MeshRenderer.material.color = new Color(_MeshRenderer.material.color.r, _MeshRenderer.material.color.g, _MeshRenderer.material.color.b, 0.5f);

    }

    public virtual void Update() {

        if(Hide) {
           if(MovingController.Instance.transform.position.y >= transform.position.y) _MeshRenderer.material.color = new Color(_MeshRenderer.material.color.r, _MeshRenderer.material.color.g, _MeshRenderer.material.color.b, 1f);
            else _MeshRenderer.material.color = new Color(_MeshRenderer.material.color.r, _MeshRenderer.material.color.g, _MeshRenderer.material.color.b, 0.5f);
        }

    }

    public virtual void OnCollisionEnter(Collision col) {
        
        

    }

    public virtual void OnCollisionExit(Collision col) {

        

    }

}
