using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering.Universal;
using UnityEngine;


public class ShopUIConrtoller : MonoBehaviour
{ 
    [System.Serializable]
   public  struct shopItem
    {
        public string itemName;
        public int itemPrice;

        public shopItem(string name, int price)
        {
            itemName = name;
            itemPrice = price;
        }
    }
   
   public GameObject mc;
    public shopItem [] items;
    
   public void BuyItem(int itemNum)
    {
        if (mc.GetComponent<PlayerInformation>().CollectedHoney >= items[itemNum].itemPrice)
        {
            PlayerPrefs.SetInt(items[itemNum].itemName, 1);
            mc.GetComponent<PlayerInformation>().SwordAura = itemNum;
            print("aaaaa");
            mc.GetComponent<ParticleChanger>().ChangeParticle();
            mc.GetComponent<PlayerInformation>().CollectedHoney -= items[itemNum].itemPrice;
            Debug.Log(items[itemNum].itemName + PlayerPrefs.GetInt(items[itemNum].itemName));
        }
    }
}