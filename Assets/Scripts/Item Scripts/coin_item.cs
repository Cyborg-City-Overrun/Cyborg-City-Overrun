using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_item : item
{
    public int moneyAmount;
    private GameObject myPlayer;

    private void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Interact")
        {
            myPlayer.GetComponent<player_control>().Transaction(moneyAmount);
            Destroy(gameObject);
        }
    }
}
