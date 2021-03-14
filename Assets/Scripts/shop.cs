using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    private GameObject myPlayer;

    public Canvas menu;

    public GameObject[] myPotions;

    public void Start()
    {
        gameObject.SetActive(true);
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Interact")
        {
            print("hello");
            menu.gameObject.SetActive(true);
        }
    }
    public void HideMe()
    {
        menu.gameObject.SetActive(false);
    }
    public void buyPotion(int id)
    {
        if (myPlayer.GetComponent<player_control>().Transaction(-myPotions[id].GetComponent<potions>().getPrice()))
        {
            myPotions[id].GetComponent<potions>().addPotion(1);
        }
    }

}
