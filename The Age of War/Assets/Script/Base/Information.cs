using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Data
{
    public int price;
    public Sprite shape;
    public Sprite Weapon;

}

public class Information : MonoBehaviour
{
    public static Information instance;

    public Data[] data;

    public Image[] monsterUI;
    public Image[] WeaponUI;
    public Text[] priceText;
    public void Start()
    {
        instance = this;

        for (int i = 0; i < data.Length; i++)
        {
            monsterUI[i].sprite = data[i].shape;
            WeaponUI[i].sprite = data[i].Weapon;
            priceText[i].text = data[i].price.ToString();
        }
    }
}