using UnityEngine;

public class ParticleChanger : MonoBehaviour
{

    public MC_InGameInformation statistics;
    public GameObject[] particles;

    public void changeParticle() {

        int i = 0;

        foreach(var particle in particles) {
            if(statistics.swordAura != i) {
                i++;
                particle.SetActive(false);
            } else {
                particle.SetActive(true);
                i++;
            }
        }
    }

}
