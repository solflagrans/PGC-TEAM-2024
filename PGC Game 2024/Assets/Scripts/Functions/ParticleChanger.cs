using UnityEngine;

public class ParticleChanger : MonoBehaviour
{

    [SerializeField] private GameObject[] _particles;

    public void ChangeParticle() {

        int i = 0;

        foreach(var particle in _particles) {
            particle.SetActive(PlayerInformation.Instance.SwordAura == i);
            i++;
        }

    }

}
