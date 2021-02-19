using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    private GameObject myPlayer;

    private GameObject myHealth;

    private GameObject myEnergy;
    public GameObject shop;

    public Slider slider;

    public void Start()
    {
        gameObject.SetActive(true);
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        myHealth = GameObject.FindGameObjectWithTag("PlayerHealthBar");
        myEnergy = GameObject.FindGameObjectWithTag("PlayerEnergyBar");
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

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Interact")
        {
            print("hello");
            shop.gameObject.SetActive(true);
        }
    }
    public void HideMe()
    {
        shop.gameObject.SetActive(false);
    }
    public void HealthPotion()
    {
        print("Health Potion: 20");

        if (myPlayer.GetComponent<player_control>().Transaction(-20))
        {
            myPlayer.GetComponent<player_control>().RestoreHealth(25);
        }
    }

}
