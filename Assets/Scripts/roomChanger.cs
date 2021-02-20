using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomChanger : MonoBehaviour
{
    public GameObject player;
    public int majorIndex;
    public Vector2[]roomPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collided");
        if(collision.tag=="Player")
        {
            int randRoom = Random.Range(0, 2);
            player.transform.position = roomPos[randRoom];

        }
    }
}
