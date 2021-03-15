﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_random : MonoBehaviour
{
    private GameObject player;
    public GameObject roomSet;
    public Saver save;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interact")
        {
            
            save.saveGame();
            int roomNum = Random.Range(0, roomSet.transform.childCount);
            player.transform.position = roomSet.transform.GetChild(roomNum).GetChild(0).transform.position; //teleport the player to the spawnpoint of the random
            //make sure that the spawn point of each room is the first child of the room
        }
    }
}
