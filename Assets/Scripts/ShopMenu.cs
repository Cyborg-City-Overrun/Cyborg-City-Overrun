using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    private GameObject myPlayer;
    public GameObject shop;

    public void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        CheckPlayerDistance();
    }

    private void CheckPlayerDistance()
    {
        if (Vector2.Distance(shop.transform.position, myPlayer.GetComponent<Transform>().position) > 1)
        {
            print("Too far. Leaving shop.");
            gameObject.SetActive(false);
        }
    }

    public void HealthPotion()
    {
        print("Health Potion: 20");
        
        if (myPlayer.GetComponent<player_control>().Transaction(-20))
        {
            myPlayer.GetComponent<player_control>().RestoreHealth(25);
        }
    }
    public void DisplayMoney()
    {
        print("Current Money: " + myPlayer.GetComponent<player_control>().myMoney);
    }
}
