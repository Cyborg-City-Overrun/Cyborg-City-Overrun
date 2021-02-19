﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_item : item
{
    public int moneyAmount;

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            hit.GetComponent<player_control>().Transaction(moneyAmount);
            Destroy(gameObject);
        }
    }
}