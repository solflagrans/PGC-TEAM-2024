using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_InGameInformation : MonoBehaviour
{
    public int hp;
    public int maxHp;
    public bool isInvulnerable;
    public int collectedHoney;
    public int maxHoneyAmount;
    public int swordAura;
    public int LevelNum;
    public List<string> collectibles;
    public List<string> shopList;
    public int maxLevel;
    public void SaveGame()
    {
        PlayerPrefs.SetFloat("posX",gameObject.transform.position.x);
        PlayerPrefs.SetFloat("posY",gameObject.transform.position.y);
        PlayerPrefs.SetFloat("posZ",gameObject.transform.position.z);
        PlayerPrefs.SetInt("LevelNumber",LevelNum);
        PlayerPrefs.SetInt("HoneyAmount",collectedHoney);
        PlayerPrefs.SetInt("MaxHoneyAmount",maxHoneyAmount);
        PlayerPrefs.SetInt("SworsEffect", swordAura);
        PlayerPrefs.SetInt("MaxLevel", maxLevel);
        for (int i = 0; i < shopList.Count; i++)
        {
            PlayerPrefs.SetInt(shopList[i],1);
        }
        Debug.Log("Game Saved");
    }

}
