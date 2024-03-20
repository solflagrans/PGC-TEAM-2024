using UnityEngine;

public class Healing : MonoBehaviour
{
    public void TryHeal() {
        int jars = PlayerInformation.Instance.CollectedHealJars;
        int maxHp = PlayerInformation.Instance.MaxHp;
        int plus = 0;
        if(jars > 0) {
            if(jars < maxHp) {
                plus += jars;
                PlayerInformation.Instance.CollectedHealJars = 0;
            } else {
                plus += maxHp;
                PlayerInformation.Instance.CollectedHealJars = jars - maxHp;
            }
            //GetComponent<Animator>().SetTrigger("");
            GetComponent<MovingController>().dieEvent.RemoveListener(GetComponent<Healing>().TryHeal);
            PlayerInformation.Instance.IsInvulnerable = false;
            PlayerInformation.Instance.Hp = plus;
            StartCoroutine(UI_Controller.Instance.FadeHP());
        } else {
            GetComponent<MovingController>().Die();
        }
    }
}