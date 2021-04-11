using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_random : MonoBehaviour
{
    private GameObject player;
    public GameObject roomSet;
    private Saver save;
    public AudioSource audio;
    public AudioClip dungeonMusic;

    private void Start()
    {
        save = FindObjectOfType<Saver>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interact")
        {
            if(this.tag=="starterDoor")
            {
                audio.clip = dungeonMusic;
                audio.Play();

            }
            save.saveGame();
            int roomNum = Random.Range(0, roomSet.transform.childCount);
            player.transform.position = roomSet.transform.GetChild(roomNum).GetChild(0).transform.position; //teleport the player to the spawnpoint of the random
            //make sure that the spawn point of each room is the first child of the room
        }
    }
}
