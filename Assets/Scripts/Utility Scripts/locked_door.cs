using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class locked_door : MonoBehaviour
{
    private GameObject player;
    public GameObject roomSet;
    private Saver save;

    public GameObject notEnoughNotif;
    public Text nENotif;

    private void Start()
    {
        save = FindObjectOfType<Saver>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerPrefs.GetInt("keyAmt") == 4) {
            if (collision.tag == "Interact")
            {
                save.saveGame();
                int roomNum = Random.Range(0, roomSet.transform.childCount);
                player.transform.position = roomSet.transform.GetChild(roomNum).GetChild(0).transform.position; //teleport the player to the spawnpoint of the random
                                                                                                                //make sure that the spawn point of each room is the first child of the room
            }
        }
        else
        {
            nENotif.text = "You don't have enough keys to unlock the door...";
            notEnoughNotif.SetActive(true);
            show();
        }
    }

    void show()
    {
        Invoke("hide", 2f);
    }

    void hide()
    {
        notEnoughNotif.SetActive(false);
    }
}
