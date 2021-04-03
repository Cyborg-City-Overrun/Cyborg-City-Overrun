using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionItem : item
{
    private GameObject myPlayer;
    private GameObject potion;

    private void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
        potion = myPlayer.GetComponent<player_control>().myPotions[0];
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Interact")
        {
            potion.GetComponent<potions>().VendPotion(0);
            Destroy(this.gameObject);
        }
    }
}
