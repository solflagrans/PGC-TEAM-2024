using System.Collections;
using System.Collections.Generic;
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
        if (mc.GetComponent<MC_InGameInformation>().collectedHoney >= items[itemNum].itemPrice)
        {
            PlayerPrefs.SetInt(items[itemNum].itemName, 1); //потом тут будет +1 к текущем колву предметов, если их меньше максимума
            mc.GetComponent<MC_InGameInformation>().collectedHoney -= items[itemNum].itemPrice;
            Debug.Log(items[itemNum].itemName + PlayerPrefs.GetInt(items[itemNum].itemName));
        }
    }
}
