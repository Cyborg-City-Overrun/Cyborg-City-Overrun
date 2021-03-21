using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionItem : item
{
    private GameObject myPlayer;
    public potions vendPotion = new potions();

    private void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Interact")
        {
            vendPotion.myID = 0;
            vendPotion.addPotion(1);
            Destroy(gameObject);
        }
    }
}
