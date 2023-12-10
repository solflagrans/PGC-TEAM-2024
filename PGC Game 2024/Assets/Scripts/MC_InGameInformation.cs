using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MC_InGameInformation : MonoBehaviour
{
    public int hp;
    public int maxHp;
    public bool isInvulnerable;
    public int collectedHoney;
    public int maxHoneyAmount;
    public int swordAura;
    public List<string> collectibles;
    public List<string> shopList;
<<<<<<< Updated upstream
    void Awake(){
        if (PlayerPrefs.HasKey("posX"))
        {
            gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("posX"),PlayerPrefs.GetFloat("posY"),PlayerPrefs.GetFloat("posZ"));
            maxHp = PlayerPrefs.GetInt("HealthPoints");
            collectedHoney = PlayerPrefs.GetInt("HoneyAmount");
            maxHoneyAmount = PlayerPrefs.GetInt("MaxHoneyAmount");
            swordAura = PlayerPrefs.GetInt("SworsEffect");
        }
                                                   
                                                   
    }
=======
        void Awake(){
            if (PlayerPrefs.HasKey("posX"))
            {
                gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("posX"),PlayerPrefs.GetFloat("posY"),PlayerPrefs.GetFloat("posZ"));
                maxHp = PlayerPrefs.GetInt("HealthPoints");
                collectedHoney = PlayerPrefs.GetInt("HoneyAmount");
                maxHoneyAmount = PlayerPrefs.GetInt("MaxHoneyAmount");
                swordAura = PlayerPrefs.GetInt("SworsEffect");
            }
                                                       
                                                       
        }
>>>>>>> Stashed changes
    public void SaveGame()
    {
        PlayerPrefs.SetFloat("posX",gameObject.transform.position.x);
        PlayerPrefs.SetFloat("posY",gameObject.transform.position.y);
        PlayerPrefs.SetFloat("posZ",gameObject.transform.position.z);
        PlayerPrefs.SetInt("ltl",SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("HoneyAmount",collectedHoney);
        PlayerPrefs.SetInt("MaxHoneyAmount",maxHoneyAmount);
        PlayerPrefs.SetInt("HealthPoints",maxHp);
        PlayerPrefs.SetInt("SworsEffect", swordAura);
        for (int i = 0; i < shopList.Count; i++)
        {
            PlayerPrefs.SetInt(shopList[i],1);
        }
        Debug.Log("Game Saved");
    }

}
