﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energy_bar_item : item
{
    private GameObject myPlayer;

    private void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Interact")
        {
            myPlayer.GetComponent<player_control>().RestoreEnergy(this.restoreAmount);
            Destroy(gameObject);
        }
    }
}
