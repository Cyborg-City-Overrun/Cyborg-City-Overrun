using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_random : MonoBehaviour
{
    public GameObject player;
    public Vector3[] roomPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interact")
        {
            int randRoom = Random.Range(0, roomPos.Length);
            player.transform.position = roomPos[randRoom];

        }
    }
}
