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
            print(Vector2.Distance(shop.transform.position, myPlayer.GetComponent<Transform>().position));
            gameObject.SetActive(false);
        }
    }

    public void HealthPotion()
    {
        print("Health Potion: 10");
        if (myPlayer.GetComponent<player_control>().money >= 10)
        {
            myPlayer.GetComponent<player_control>().money -= 10;
            print("Purchased");
            print(myPlayer.GetComponent<player_control>().money);
            myPlayer.GetComponent<player_control>().RestoreHealth(25);
        }
        else
        {
            print("Not enough money");
        }
    }
}
