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
    public shopItem[] items;
    public GameObject[] buttons;
   public GameObject mc;
   
   public void BuyItem(int itemNum)
    {
       if (PlayerInformation.Instance.CollectedHoney >= items[itemNum].itemPrice)
        {
            PlayerPrefs.SetInt(items[itemNum].itemName, 1);
            PlayerInformation.Instance.CollectedHoney -= items[itemNum].itemPrice;
            Debug.Log(items[itemNum].itemName + PlayerPrefs.GetInt(items[itemNum].itemName));
            for (int i = buttons.Length - 1; i > itemNum; i--)
            {
                buttons[i].transform.position = buttons[i - 1].transform.position;
            }
            buttons[itemNum].SetActive(false);
            if (items[itemNum].itemName == "hp")
            {
                PlayerInformation.Instance.MaxHp += 1;
                PlayerInformation.Instance.Hp += 1;
               PlayerPrefs.SetInt("Hp", PlayerInformation.Instance.Hp += 1);
               print(PlayerInformation.Instance.Hp);
            }
            else if (items[itemNum].itemName == "aura"){
               print("aura");
            }
            else if (items[itemNum].itemName == "scroll"){
                           print("scroll");
             }
          }
    }
}
